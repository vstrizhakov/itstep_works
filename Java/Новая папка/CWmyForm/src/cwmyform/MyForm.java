/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cwmyform;

import java.awt.Button;
import java.awt.Checkbox;
import java.awt.FlowLayout;
import java.awt.Frame;
import java.awt.TextField;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.ItemEvent;
import java.awt.event.ItemListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;

/**
 *
 * @author Programmer
 */
public class MyForm extends Frame {

    private Button btn1;
    private Button btn2;
    private TextField tfOne;
    private TextField tfTwo;
    private Checkbox cb1;

    public MyForm() {
        this.setTitle("Second GUI");
        this.setSize(600, 400);
        this.setLayout(new FlowLayout(FlowLayout.LEFT, 3, 3));

        this.tfOne = new TextField();
        this.tfOne.setText("Gates");
        this.add(this.tfOne);

        this.tfTwo = new TextField();
        this.tfTwo.setText("Bill");
        this.add(this.tfTwo);

        this.cb1 = new Checkbox();
        this.cb1.setLabel("Программирование");
        this.add(cb1);

        this.btn1 = new Button();
        this.btn1.setLabel("One");
        this.add(this.btn1);

        this.btn2 = new Button();
        this.btn2.setLabel("Two");
        this.add(this.btn2);

        ActionListener AL = new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent ae) {
                if (ae.getSource() == MyForm.this.btn1) {
                    System.err.println("Первая кнопка");
                } else if (ae.getSource() == MyForm.this.btn2) {
                    System.err.println("Вторая кнопка");
                }
                System.out.println("Первое текстовое поле : " + MyForm.this.tfOne.getText());
                System.out.println("Второе текстовое поле : " + MyForm.this.tfTwo.getText());
                System.out.println("Checkbox : " + MyForm.this.cb1.getState());
            }
        };
        this.btn1.addActionListener(AL);
        this.btn2.addActionListener(AL);

        this.cb1.addItemListener(
                new ItemListener() {
            @Override
            public void itemStateChanged(ItemEvent e) {
                if (e.getStateChange() == ItemEvent.SELECTED) {
                    System.out.println("Выбран");
                } else if (e.getStateChange() == ItemEvent.DESELECTED) {
                    System.out.println("Не выбран");
                } else {
                    System.out.println("Не известно");
                }
            }
        });
        this.addMouseListener(
                new MouseListener() {
            @Override
            public void mouseClicked(MouseEvent e) {  // клик мыши
                System.out.println("Клик мыши");
                System.err.println("x = " + e.getX() + ", y = " + e.getY());
                switch (e.getButton()) {
                    case MouseEvent.BUTTON1:
                        System.err.println("Первая");
                        break;
                    case MouseEvent.BUTTON2:
                        System.err.println("Вторая");
                        break;
                    case MouseEvent.BUTTON3:
                        System.err.println("Третья");
                        break;
                }
            }

            @Override
            public void mousePressed(MouseEvent e) { // нажатие мыши
                System.out.println("нажатие мыши");
                   System.err.println("x = " + e.getX() + ", y = " + e.getY());
                switch (e.getButton()) {
                    case MouseEvent.BUTTON1:
                        System.err.println("Первая");
                        break;
                    case MouseEvent.BUTTON2:
                        System.err.println("Вторая");
                        break;
                    case MouseEvent.BUTTON3:
                        System.err.println("Третья");
                        break;
                }
            }

            @Override
            public void mouseReleased(MouseEvent e) { // отпускание мыши
                System.out.println("отпускание мыши");
                   System.err.println("x = " + e.getX() + ", y = " + e.getY());
                switch (e.getButton()) {
                    case MouseEvent.BUTTON1:
                        System.err.println("Первая");
                        break;
                    case MouseEvent.BUTTON2:
                        System.err.println("Вторая");
                        break;
                    case MouseEvent.BUTTON3:
                        System.err.println("Третья");
                        break;
                }
            }

            @Override
            public void mouseEntered(MouseEvent e) { // наведение мыши
                System.out.println("наведение мыши");
                   System.err.println("x = " + e.getX() + ", y = " + e.getY());
                switch (e.getButton()) {
                    case MouseEvent.BUTTON1:
                        System.err.println("Первая");
                        break;
                    case MouseEvent.BUTTON2:
                        System.err.println("Вторая");
                        break;
                    case MouseEvent.BUTTON3:
                        System.err.println("Третья");
                        break;
                }
            }

            @Override
            public void mouseExited(MouseEvent e) { // уведение мыши
                System.out.println("уведение мыши");
                   System.err.println("x = " + e.getX() + ", y = " + e.getY());
                switch (e.getButton()) {
                    case MouseEvent.BUTTON1:
                        System.err.println("Первая");
                        break;
                    case MouseEvent.BUTTON2:
                        System.err.println("Вторая");
                        break;
                    case MouseEvent.BUTTON3:
                        System.err.println("Третья");
                        break;
                }
            }

        });
    }

}
