/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package forms;
import java.awt.Frame;
import java.awt.Button;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

/**
 *
 * @author PC
 */
public class MyForm extends Frame
{
    public MyForm()
    {
        this.setSize(500, 300);
        this.setTitle("Заголовок окна");
        
        Button btn = new Button();
        btn.setLabel("Click me");
        btn.setLocation(20, 20);
        btn.setSize(100, 30);
        
        this.add(btn);
        
        btn.addActionListener(new ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent ae)
            {
                System.out.println("Нажата кнопка");
                System.exit(0);
            }
        });
    }
}
