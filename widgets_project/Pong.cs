

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
    private (float x, float y) _ballVelocity => (_ballDirection.x * _ballSpeed, _ballDirection.y * _ballSpeed);
    private (float x, float y) _ballDirection;
    private (float x, float y) _ballFloatPos;
    private bool _gameFinished;

    private (int current, int max) _paddleUpdateSpeed;
    private float _ballSpeed;
    private int _ballDiameter;
    private int _ballRadius => _ballDiameter / 2;
    
    public Pong() {
        _gameFinished = false;
        _size = (80, 80);
        _renderer = new AsciiRenderer(_size.x, _size.y);
        _ballDiameter = 3;
        _ball = new Circle((uint)_ballDiameter, new Position(_size.x / 2, _size.y / 2));
        _ballDirection = (0.5f, -1);
        _paddleTop = new Rect(11, 3, new Position(_size.x / 4, _size.y - 10));
        _paddleBottom = new Rect(11, 3, new Position(_size.x / 3, 10));
        _paddleUpdateSpeed = (0, 1);
        _ballFloatPos = (_size.x / 2, _size.y / 2);
        _ballSpeed = 1.2f;
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
        _paddleUpdateSpeed.current += 1;
        if (_paddleUpdateSpeed.current >= _paddleUpdateSpeed.max) {
            _paddleUpdateSpeed.current = 0;
            UpdatePaddles();
        }
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

    private void CheckBallWallCollisions() {
        if (_ball.Position.y <= (_ballDiameter / 2)) { _ballDirection.y = Math.Abs(_ballDirection.y); }
        if (_ball.Position.y >= _size.y - (_ballDiameter / 2)) { _ballDirection.y = -Math.Abs(_ballDirection.y); }
        if (_ball.Position.x <= (_ballDiameter / 2)) { _ballDirection.x = Math.Abs(_ballDirection.x); }
        if (_ball.Position.x >= _size.x - (_ballDiameter / 2)) { _ballDirection.x = -Math.Abs(_ballDirection.x); }
    }

    private void CheckBallPaddleCollision(Rect paddle) {
        if (((_ball.Position.y - _ballRadius <= paddle.Position.y + (paddle.Height / 2) &&
            _ball.Position.y - _ballRadius >= paddle.Position.y - (paddle.Height / 2)) ||
            (_ball.Position.y + _ballRadius >= paddle.Position.y - (paddle.Height / 2) &&
            _ball.Position.y + _ballRadius <= paddle.Position.y + (paddle.Height / 2))) &&
            ((_ball.Position.x - _ballRadius <= paddle.Position.x + (paddle.Width / 2) &&
            _ball.Position.x - _ballRadius >= paddle.Position.x - (paddle.Width / 2)) ||
            (_ball.Position.y + _ballRadius >= paddle.Position.x - (paddle.Width / 2) &&
            _ball.Position.y + _ballRadius <= paddle.Position.x + (paddle.Width / 2)))
        ) {
            var xDif = _ball.Position.x - paddle.Position.x;
            var xPercentDif = xDif / ((float)paddle.Width / 2);
            _ballDirection.x = xPercentDif * 3;
            if (_ball.Position.y <= _size.y / 2) { _ballDirection.y = 1; }
            else { _ballDirection.y = -1; }
        }

    }



}