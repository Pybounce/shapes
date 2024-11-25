public class WidgetUtils {
    public static void CheckDimentions(params uint[] dimentions) {
        foreach (var dimention in dimentions) {
            if (dimention <= 0) {
                throw new Exception("Widget dimentions must be greater than 0");
            }
        }
    }
}