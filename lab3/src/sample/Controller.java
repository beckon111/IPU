package sample;
import javafx.application.Platform;
import javafx.fxml.FXML;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Controller {

    @FXML
    private Label percentageLabel;

    @FXML
    private Label timeLabel;

    @FXML
    private Label powerModeLabel;

    @FXML
    private TextField minutesEdit;

    class BatteryStatusChecker extends TimerTask {

        private String[] getBatteryData() throws IOException {
            String[] batteryData = new String[5];

            Process p = Runtime.getRuntime().exec("pmset -g batt");

            BufferedReader input = new BufferedReader(new InputStreamReader(p.getInputStream()));
            String line = input.readLine();
            line = line.substring(line.indexOf("'") + 1, line.lastIndexOf("'"));
            batteryData[0] = line;
            line = input.readLine();
            line = line.split("\t")[1];
            batteryData[1] = line.substring(0, line.indexOf('%')+1);
            if (!line.contains("(no estimate)")) {
                batteryData[2] = line.split(" ")[2];
            } else {
                batteryData[2] = "Calculating";
            }
            return batteryData;
        }

        public void run() {
            Platform.runLater(new Runnable() {
                public void run() {

                    String[] batteryData = new String[5];
                    try {
                        batteryData = getBatteryData();
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                    powerModeLabel.setText(batteryData[0]);
                    timeLabel.setText(batteryData[1]);
                    percentageLabel.setText(batteryData[2]);
                    try {
                        if (batteryData[0].indexOf("Battery") == -1) {
                            Process p = Runtime.getRuntime().exec("sudo pmset displaysleep " + minutesEdit.getText());

                        } else {
                            Process p = Runtime.getRuntime().exec("sudo pmset displaysleep 1");
                        }
                    } catch(IOException e) {
                        e.printStackTrace();
                    }
                }
            });

        }

    }

    @FXML
    public void initialize() {
        Timer timer = new Timer();
        timer.schedule(new BatteryStatusChecker(), 0,3000);
        minutesEdit.setText("30");
    }

}
