/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cwborderlayout;

import java.awt.BorderLayout;
import java.awt.Button;
import java.awt.Frame;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;

/**
 *
 * @author Programmer
 */
public class MyForm extends Frame{
    public MyForm(){
      this.addWindowListener(new WindowAdapter() {
            @Override
            public void windowClosing(WindowEvent we) {
                System.exit(0);
            }
        });
        
        this.setLayout(new BorderLayout());
        this.setSize(500, 300);
         Button B1 = new Button();
            B1.setLabel("NORTH");
            this.add(B1, BorderLayout.NORTH);
            
             Button B2 = new Button();
            B2.setLabel("SOUTH");
            this.add(B2, BorderLayout.SOUTH);
            
             Button B3 = new Button();
            B3.setLabel("WEST");
            this.add(B3, BorderLayout.WEST);
            
             Button B4 = new Button();
            B4.setLabel("EAST");
            this.add(B4, BorderLayout.EAST);
            
             Button B5 = new Button();
            B5.setLabel("CENTER");
            this.add(B5, BorderLayout.CENTER);
    }
}
