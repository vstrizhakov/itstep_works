/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dbconnection;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Properties;

/**
 *
 * @author PC
 */
public class DbConnection {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        try
        {
            Class.forName("com.mysql.jdbc.Driver").newInstance();
        }
        catch (Exception ex) {
            System.out.println("Error (" + ex.getClass().getName() + "): " + ex.getMessage());
        }
        String url = "jdbc:mysql://10.3.11.10:3306/sp2822db?user=sp2822user&password=sp2822pswd&useUnicode=true&characterEncoding=utf8";
        try
        {
            Properties prop = new Properties();
            prop.put("user", "sp2822user");
            prop.put("password", "sp2822pswd");
            prop.put("useUnicode", "true");
            prop.put("characterEncoding", "utf8");
            
            Connection con = DriverManager.getConnection(url, prop);
            System.out.println("Connected to MySql successfully");
            
            ResultSet result = con.createStatement().executeQuery("SELECT * FROM books");
            while (result.next())
            {
                int id = result.getInt("id");
                String name = result.getString("name");
                String izd = result.getString("izd");
                String category = result.getString("category");
                System.out.println(id + ", " + name + ", " + izd + ", " + category);
            }
            result.close();            
            con.close();
            
//            int count = con.createStatement().executeUpdate("INSERT INTO products(name, price, weight) VALUES (\"Snickers\", 12.5, 45)");
//            System.out.println("Добавление строк: " + count);
        }
        catch (SQLException ex) {
            System.out.println("Error: " + ex.getMessage());
        }
    }
    
}
