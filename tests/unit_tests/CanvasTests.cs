
using Moq;

namespace unit_tests;

public class CanvasTests {
    
    private Mock<IWidgetRenderer> _mockRenderer;
    private Canvas _canvas;

    [SetUp]
    public void Setup() {
        _mockRenderer = new Mock<IWidgetRenderer>();
        _canvas = new Canvas(_mockRenderer.Object);
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(5)]
    public void AddWidgets___VariedAmount___AddsCorrectWidgets(int widgetCount) {
        //arrange
        var widgetsAdded = new IWidget[widgetCount];
        
        for (int i = 0; i < widgetCount; i++) {
            widgetsAdded[i] = new Mock<IWidget>().Object;
        }

        //act
        _canvas.AddWidgets(widgetsAdded);
        _canvas.Draw();

        //assert
        _mockRenderer.Verify(r => r.Draw(It.Is<IEnumerable<IWidget>>(s => s.SequenceEqual(widgetsAdded))));
    
    }   

    [Test]
    public void AddWidgets___MutateOriginalArray___DoesNotEffectCanvasWidgets() {
        //arrange
        var widgetsAdded = new IWidget[2] {
            new Mock<IWidget>().Object,
            new Mock<IWidget>().Object
        };
        
        //act
        _canvas.AddWidgets(widgetsAdded);
        _canvas.Draw();
        widgetsAdded[0] = new Mock<IWidget>().Object;


        //assert
        _mockRenderer.Verify(r => r.Draw(It.Is<IEnumerable<IWidget>>(s => !s.SequenceEqual(widgetsAdded))));
    
    }   

}