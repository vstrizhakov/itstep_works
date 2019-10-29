/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cwflowlayout;

import java.awt.Button;
import java.awt.FlowLayout;
import java.awt.Frame;
import java.awt.GridLayout;
import java.awt.Panel;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import javax.swing.BoxLayout;

/**
 *
 * @author Programmer
 */
public class MyForm extends Frame {

    public MyForm() {
        this.setTitle("менеджеры раскладкти : FlowLayout");
        this.setSize(500, 300);
        //   this.setLayout(new FlowLayout(FlowLayout.LEFT,5,5));
        // this.setLayout(new GridLayout(4,5));

//        for (int i = 0; i < 20; i++) {
//            Button B = new Button();
//            B.setLabel("Hello "+i);
//            this.add(B);
//        }
// 2------------------------------------------------------
//        this.setLayout(new GridLayout(3, 3));
//
//        for (int i = 0; i < 9; i++) {
//            Panel P = new Panel();
//            P.setLayout(new FlowLayout(FlowLayout.CENTER, 3, 3));
//            this.add(P);
//            for (int j = 0; j < 3; j++) {
//                Button B = new Button();
//                B.setLabel("Hello " + (i*10+j));
//                P.add(B);
//            }
//        }
//3--------------------------------------------------------------
//        BoxLayout BL = new BoxLayout(this, BoxLayout.LINE_AXIS);
//        this.setLayout(BL);
//        for (int i = 0; i < 700; i++) {
//            Button B = new Button();
//                B.setLabel("Button " + i);
//                this.add(B);
//        }
        //4--------------------------------------------------------------
        BoxLayout BL = new BoxLayout(this, BoxLayout.LINE_AXIS);
        this.setLayout(BL);

        Panel PL = new Panel();
        Panel PR = new Panel();

        this.add(PL);
        this.add(PR);
        PL.setLayout(new BoxLayout(PL, BoxLayout.Y_AXIS));
        PR.setLayout(new BoxLayout(PR, BoxLayout.Y_AXIS));

        for (int i = 0; i < 3; i++) {
            Button B = new Button();
            B.setLabel("Left " + i);
            PL.add(B);
        }
         for (int i = 0; i < 3; i++) {
            Button B = new Button();
            B.setLabel("Right " + i);
            PR.add(B);
        }

        this.addWindowListener(new WindowAdapter() {
            @Override
            public void windowClosing(WindowEvent we) {
                System.exit(0);
            }
        });
    }
}
