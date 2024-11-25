

public interface IWidget {
    public Position Position { get; set; }
    public void DrawWith(IWidgetRenderer renderer);
}