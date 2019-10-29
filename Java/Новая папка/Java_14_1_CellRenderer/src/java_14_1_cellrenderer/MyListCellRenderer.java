/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package java_14_1_cellrenderer;

import java.awt.Color;
import java.awt.Component;
import java.awt.Dimension;
import java.awt.GridLayout;
import java.awt.Image;
import java.net.URL;
import javax.swing.ImageIcon;
import javax.swing.JComponent;
import javax.swing.JLabel;
import javax.swing.JList;
import javax.swing.JPanel;
import javax.swing.JTextField;
import javax.swing.ListCellRenderer;

/**
 *
 * @author 09220
 */
public class MyListCellRenderer implements ListCellRenderer<Persona>
{
    private static ImageIcon iconMan;
    private static ImageIcon iconWoman;

    static
    {
        URL urlMan = MyListCellRenderer.class.getResource("/resources/true1.png");
        URL urlWoman = MyListCellRenderer.class.getResource("/resources/false1.png");

        if (urlMan != null)
        {
            iconMan = new ImageIcon(urlMan);
            //для изменения размера картинки
            Image image = iconMan.getImage();
            Image newimg = image.getScaledInstance(26, 26, java.awt.Image.SCALE_SMOOTH);
            iconMan = new ImageIcon(newimg);
        }
        else
            System.out.println("Error image1");
        
        if (urlWoman != null)
        {
            iconWoman = new ImageIcon(urlWoman);
            Image image = iconWoman.getImage();
            Image newimg = image.getScaledInstance(26, 26, java.awt.Image.SCALE_SMOOTH);
            iconWoman = new ImageIcon(newimg);
        }
        else
            System.out.println("Error image2");
    }

    @Override
    public Component getListCellRendererComponent(JList<? extends Persona> list, Persona value, int index, boolean isSelected, boolean cellHasFocus)
    {
        JPanel panel = new JPanel(new GridLayout(1,4));
        
        JLabel L = new JLabel((value.getgender())?iconMan:iconWoman);
        L.setPreferredSize(new Dimension(32, 32));
        JLabel TF1 = new JLabel(value.getLastname().trim());
        JLabel TF2 = new JLabel(value.getFirstname().trim());
        JLabel TF3 = new JLabel(Integer.toString(value.getAge()));
       
        panel.add(L);
        panel.add(TF1);
        panel.add(TF2);
        panel.add(TF3);
        
        if(isSelected)
        {
            panel.setBackground(new Color(180, 0, 80));
            TF1.setForeground(Color.WHITE);
            TF2.setForeground(Color.WHITE);
            TF3.setForeground(Color.WHITE);
        }
        
        return panel;
    }
    
}
