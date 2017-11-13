package sample;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Main extends Application {

    @Override
    public void start(Stage primaryStage) throws Exception {
        Parent root = FXMLLoader.load(getClass().getResource("sample.fxml"));
        primaryStage.setTitle("Battery Info Viewer");
        primaryStage.setScene(new Scene(root, 300, 275));
        primaryStage.show();
        String defaultMin = new String();
        Process p = Runtime.getRuntime().exec("pmset -g");

        BufferedReader input = new BufferedReader(new InputStreamReader(p.getInputStream()));
        String line = new String();
        while ((line = input.readLine()) != null) {
            if (line.indexOf("displaysleep") != -1) {
                defaultMin = line.substring(line.lastIndexOf(" ") + 1);
                System.out.println("Home value" + defaultMin);
            }
        }
        String finalDefaultMin = defaultMin;
        Runtime.getRuntime().addShutdownHook(new Thread() {
            public void run() {
                System.out.println("Changed to home");
                try {
                    Process p = Runtime.getRuntime().exec("sudo pmset displaysleep "+ finalDefaultMin);
                } catch (IOException e) {
                    e.printStackTrace();
                }

            }
        });
    }

    public static void main(String[] args) {
        launch(args);
    }
}
