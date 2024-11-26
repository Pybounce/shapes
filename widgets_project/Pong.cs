

using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

public class Pong {
    private readonly (int x, int y) _size;
    private readonly AsciiRenderer _renderer;
    private Circle _ball;
    private Rect _paddleTop;
    private Rect _paddleBottom;
    private (int x, int y) _ballVelocity => (_ballDirection.x * _ballSpeed, _ballDirection.y * _ballSpeed);
    private (int x, int y) _ballDirection;
    private bool _gameFinished;

    private (int current, int max) _paddleUpdateSpeed;
    private int _ballSpeed;
    private int _ballDiameter;
    
    public Pong() {
        _gameFinished = false;
        _size = (80, 80);
        _renderer = new AsciiRenderer(_size.x, _size.y);
        _ballDiameter = 3;
        _ball = new Circle((uint)_ballDiameter, new Position(_size.x / 2, _size.y / 2));
        _ballDirection = (0, -1);
        _paddleTop = new Rect(11, 3, new Position(_size.x / 4, _size.y - 10));
        _paddleBottom = new Rect(11, 3, new Position(_size.x, 10));
        _paddleUpdateSpeed = (0, 1);
        _ballSpeed = 1;
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
        UpdateBallPos();
        CheckBallWallCollisions();
        _paddleUpdateSpeed.current += 1;
        if (_paddleUpdateSpeed.current >= _paddleUpdateSpeed.max) {
            _paddleUpdateSpeed.current = 0;
            UpdatePaddles();
        }
        Draw();
    }

    private void UpdatePaddles() {
        var paddlePos = _ballVelocity.y > 0 ? _paddleTop.Position : _paddleBottom.Position;
        if (paddlePos.x > _ball.Position.x) {
            paddlePos.x -= 1;
        }
        else {
            paddlePos.x += 1;
        }
        if (_ballVelocity.y > 0) { _paddleTop.Position = paddlePos; }
        else { _paddleBottom.Position = paddlePos; }
    }


    private void UpdateBallPos() {
        _ball.Position += new Position(_ballVelocity.x, _ballVelocity.y); 
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

}