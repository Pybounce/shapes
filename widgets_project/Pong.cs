

using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public class Pong {
    private readonly (int x, int y) _size;
    private readonly AsciiRenderer _renderer;
    private Circle _ball;
    private Rect _paddleTop;
    private Rect _paddleBottom;
    private (float x, float y) _ballVelocity => (_ballDirection.x * _ballSpeed.cur, _ballDirection.y * _ballSpeed.cur);
    private (float x, float y) _ballDirection;
    private (float x, float y) _ballFloatPos;
    private bool _gameFinished;
    private (float cur, float max, float start) _ballSpeed;
    private float _ballAcceleration;
    private int _ballDiameter;
    private float _ballRadius => (float)_ballDiameter / 2;
    private (int cur, int max) _games;
    public Pong(int gameCount) {
        _gameFinished = false;
        _size = (Console.WindowWidth / 2, Console.WindowHeight);
        _renderer = new AsciiRenderer(_size.x, _size.y);
        _games = (cur: 0, max: gameCount);
        ResetBall();
        ResetPaddles();
    }

    public async Task Play() {
        var millisecondDelay = 32;
        var millisecondGameTimeout = 60_000;
        int i = 0;
        while (_gameFinished == false) {
            i++;
            Tick();
            await Task.Delay(millisecondDelay);
            if (i > millisecondGameTimeout / millisecondDelay) {
                Console.WriteLine("time expired");
                return;
            }
        }
    }

    private void Tick() {
        NormaliseBallDirection();
        UpdateBallPos();
        CheckBallWallCollisions();
        CheckBallPaddleCollision(_paddleBottom);
        CheckBallPaddleCollision(_paddleTop);
        UpdatePaddles();
        Draw();
    }

    private void UpdatePaddles() {
        var paddlePos = _ballVelocity.y > 0 ? _paddleTop.Position : _paddleBottom.Position;
        if (_ball.Position.x > paddlePos.x + 2) {
            paddlePos.x += 1;
        }
        else if (_ball.Position.x < paddlePos.x - 2) {
            paddlePos.x -= 1;
        }
        if (_ballVelocity.y > 0) { _paddleTop.Position = paddlePos; }
        else { _paddleBottom.Position = paddlePos; }
    }


    private void UpdateBallPos() {
        _ballFloatPos.x += _ballVelocity.x;
        _ballFloatPos.y += _ballVelocity.y;
        _ball.Position = new Position((int)_ballFloatPos.x, (int)_ballFloatPos.y); 
    }
    private void NormaliseBallDirection() {
        var dirMag = (float)Math.Sqrt(Math.Pow(_ballDirection.x, 2) + Math.Pow(_ballDirection.y, 2));
        _ballDirection.x /= dirMag;
        _ballDirection.y /= dirMag;
    }
    private void Draw() {
        var canvas = new Canvas(_renderer, _ball, _paddleTop, _paddleBottom);
        canvas.Draw();
    }

    private void GoalHit() {
        _games.cur += 1;
        ResetBall();
        ResetPaddles();
        if (_games.cur >= _games.max) {
            _gameFinished = true;
        }
    }

    private void CheckBallWallCollisions() {
        if (_ball.Position.y <= (_ballDiameter / 2) || _ball.Position.y >= _size.y - 1 - (_ballDiameter / 2)) { 
            GoalHit();
        }
        if (_ball.Position.x <= (_ballDiameter / 2)) { _ballDirection.x = Math.Abs(_ballDirection.x); }
        if (_ball.Position.x >= _size.x - 1 - (_ballDiameter / 2)) { _ballDirection.x = -Math.Abs(_ballDirection.x); }
    }

    private void CheckBallPaddleCollision(Rect paddle) {
        if (((_ball.Position.y - _ballRadius <= paddle.Position.y + (paddle.Height / 2) &&
            _ball.Position.y - _ballRadius >= paddle.Position.y - (paddle.Height / 2)) ||
            (_ball.Position.y + _ballRadius >= paddle.Position.y - (paddle.Height / 2) &&
            _ball.Position.y + _ballRadius <= paddle.Position.y + (paddle.Height / 2))) &&
            ((_ball.Position.x - _ballRadius <= paddle.Position.x + (paddle.Width / 2) &&
            _ball.Position.x - _ballRadius >= paddle.Position.x - (paddle.Width / 2)) ||
            (_ball.Position.x + _ballRadius >= paddle.Position.x - (paddle.Width / 2) &&
            _ball.Position.x + _ballRadius <= paddle.Position.x + (paddle.Width / 2)))
        ) {
            var xDif = _ball.Position.x - paddle.Position.x;
            var xPercentDif = xDif / ((float)paddle.Width / 2);
            _ballDirection.x = xPercentDif * 2f;
            if (_ball.Position.y <= _size.y / 2) { _ballDirection.y = 1; }
            else { _ballDirection.y = -1; }
            _ballSpeed.cur += _ballAcceleration;
            _ballSpeed.cur = Math.Min(_ballSpeed.cur, _ballSpeed.max);
        }

    }

    private void ResetBall() {
        _ballDiameter = 3;
        _ball = new Circle((uint)_ballDiameter, new Position(_size.x / 2, _size.y / 2));
        _ballFloatPos = (_size.x / 2, _size.y / 2);
        _ballSpeed = (cur: 1.2f, max: 2f, start: 1.2f);
        _ballAcceleration = 0.1f;
        var rng = new Random();
        _ballDirection = (rng.Next(-100, 100) / 100f, (rng.Next(0, 1) * 2) - 1);
        _ballSpeed.cur = _ballSpeed.start;
        NormaliseBallDirection();
    }
    private void ResetPaddles() {
        _paddleTop = new Rect(11, 3, new Position(_size.x / 2, _size.y - 10));
        _paddleBottom = new Rect(11, 3, new Position(_size.x / 2, 10));
    }


}