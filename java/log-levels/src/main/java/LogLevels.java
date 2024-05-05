public class LogLevels {
    
    public static String message(String logLine) {
        return logLine.replaceAll("\\s*\\[.*\\]:\\s*", "").trim();
    }

    public static String logLevel(String logLine) {
        return logLine.replaceAll("\\s*\\[(.*)\\]:.*", "$1").trim().toLowerCase();
    }

    public static String reformat(String logLine) {
        return message(logLine) + " (" + logLevel(logLine) + ")";
    }
}
