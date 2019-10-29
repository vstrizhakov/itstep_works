/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package products;

import java.awt.event.*;

/**
 *
 * @author PC
 */
public class Products
{
    public static void main(String[] args) {
        DbConnection db = new DbConnection("127.0.0.1", "products", "root", "");
        try
        {
            db.Initialize();
            Form f = new Form(db);
            f.addWindowListener(new WindowAdapter()
            {
                @Override
                public void windowClosing(WindowEvent we)
                {
                    db.close();
                }
            });
            f.setVisible(true);
        }
        catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
    }
    
    static public double toDouble(Object str)
    {
        try
        {
            if (str instanceof Double) return (Double)str;
            return Double.valueOf((String)str);
        }
        catch (Exception ex) {
            return 0;
        }
    }
    
    static public int toInt(Object str)
    {
        try
        {
            return Integer.valueOf((String)str);
        }
        catch (Exception ex) {
            System.out.println(ex.getMessage());
            return 0;
        }
    }
}
