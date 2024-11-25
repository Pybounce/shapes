
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

    [TestCase(0, false)]
    [TestCase(1, false)]
    [TestCase(5, false)]
    [TestCase(0, true)]
    [TestCase(1, true)]
    [TestCase(5, true)]
    public void AddWidgetsAndDraw___VariedAmount___AddsAndDrawsCorrectWidgets(int widgetCount, bool addViaConstructor) {
        //arrange
        var widgetsAdded = new IWidget[widgetCount];
        
        for (int i = 0; i < widgetCount; i++) {
            widgetsAdded[i] = new Mock<IWidget>().Object;
        }
    
        //act
        if (addViaConstructor) { _canvas = new Canvas(_mockRenderer.Object, widgetsAdded); }
        else { _canvas.AddWidgets(widgetsAdded); }
        _canvas.Draw();

        //assert
        _mockRenderer.Verify(r => r.Draw(It.Is<IEnumerable<IWidget>>(s => s.SequenceEqual(widgetsAdded))));
    }   

    [Test]
    public void AddWidgetsAndDraw___MutateOriginalWidgetArray___DoesNotEffectCanvasWidgets() {
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

    [Test]
    public void AddWidgets___NullConstructorInput___ActsAsEmptyWithNoErrors() {
        //arrange
        var widgets = new IWidget[2] {
            new Mock<IWidget>().Object,
            new Mock<IWidget>().Object
        };
        _canvas = new Canvas(_mockRenderer.Object, null);
        
        //act
        _canvas.AddWidgets(widgets);
        _canvas.Draw();

        //assert
        _mockRenderer.Verify(r => r.Draw(It.Is<IEnumerable<IWidget>>(s => s.SequenceEqual(widgets))));
    }

}