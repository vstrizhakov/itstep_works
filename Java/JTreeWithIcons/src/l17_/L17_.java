/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package l17_;

import java.awt.BorderLayout;
import java.awt.FlowLayout;
import java.awt.Image;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import javax.swing.ImageIcon;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JTree;
import javax.swing.tree.DefaultMutableTreeNode;
import javax.swing.tree.DefaultTreeCellRenderer;
import javax.swing.tree.TreePath;

/**

 @author mrmid
 */
public class L17_
{

 /**
  @param args the command line arguments
  */
 public static void main(String[] args)
 {
   MyFrame f = new MyFrame();
   f.setVisible(true);
 }
 /*
   Color getBackgroundNonSelectionColor()
   Color getBackgroundSelectionColor()
   Color getBorderSelectionColor()
 
   Icon getClosedIcon()
   Icon getDefaultClosedIcon()
 
   Icon getDefaultLeafIcon() // Leaf - "Узел", не имеющий потомков
   Icon getDefaultOpenIcon()
 
   Icon getLeafIcon()
   Icon getOpenIcon()
 
   Color getTextNonSelectionColor()
 
 */
}

class MyFrame extends JFrame
{
   private JPanel mainPanel; // главная панель которая будет назначена фрейму как главный контейнер
   private  JTree tree;
   
   protected static ImageIcon createImageIcon(String path)
   {
     java.net.URL imageURL = MyFrame.class.getResource(path);
     if(imageURL !=null)
     {
      return new ImageIcon(new ImageIcon(imageURL).getImage().getScaledInstance(40, 40, Image.SCALE_DEFAULT));
     }
     else{
      System.out.println("Не найден путь");
      return null;
     }
   }
   
   public MyFrame()
   {
    this.mainPanel = new JPanel();                                              
    this.mainPanel.setLayout(new BorderLayout());  
    
    this.setTitle("ListBox");                                     
    this.setLayout(new BorderLayout());
    this.setContentPane(this.mainPanel);                                         
    this.setSize(400,500);     
    
     DefaultMutableTreeNode root = new DefaultMutableTreeNode("Корневой элемент");
     this.tree = new JTree(root);
     this.mainPanel.add(this.tree, BorderLayout.CENTER);
     
     // заполняем дерево
    for(int i = 0; i < 10; i++)
     {
       DefaultMutableTreeNode node = new DefaultMutableTreeNode("Узел первого уровня " + i);
       root.add(node);

       for(int j = 0; j < 10; j++)
       {
         DefaultMutableTreeNode n2 = new DefaultMutableTreeNode("Узел второго уровня " + (i * 10 + j));
         node.add(n2);
       }
     }
    
     tree.expandPath(new TreePath(new Object[]
    {
      root, root.children().nextElement()
    }));
     
     ImageIcon leafIcon = createImageIcon("../resources/1.png");
     ImageIcon openIcon = createImageIcon("../resources/2.png");
     ImageIcon closeIcon = createImageIcon("../resources/3.png");
     
     DefaultTreeCellRenderer renderer = new DefaultTreeCellRenderer();
     if(leafIcon !=null)
      renderer.setLeafIcon(leafIcon);
     if(openIcon !=null)
      renderer.setOpenIcon(openIcon);
     if(closeIcon !=null)
      renderer.setClosedIcon(closeIcon);
     
     this.tree.setCellRenderer(renderer);
    
     // ________ обработчик закрытия окна
     this.addWindowListener(                         
      new WindowAdapter()                             
      {
        @Override
        public void windowClosing(WindowEvent we) 
        {
          System.exit(0);
        }
      });
   } // конец конструктора
}