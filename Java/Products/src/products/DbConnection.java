/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package products;

import com.mysql.jdbc.Statement;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Properties;

/**
 *
 * @author PC
 */
public class DbConnection
{
    private String _ip;
    private String _dbName;
    private String _username;
    private String _password;
    private Connection _connection;
    private boolean _isReady = false;
    
    public DbConnection(String ip, String dbName, String username, String password)
    {
        _ip = ip;
        _dbName = dbName;
        _username = username;
        _password = password;
    }
    
    public void Initialize() throws Exception
    {
        try
        {
            Class.forName("com.mysql.jdbc.Driver").newInstance();
            String url = "jdbc:mysql://" + _ip + "/" + _dbName;
            Properties prop = new Properties();
            prop.put("user", _username);
            prop.put("password", _password);
            prop.put("useUnicode", "true");
            prop.put("characterEncoding", "utf8");

            _connection = DriverManager.getConnection(url, prop);
            System.out.println("Connected to MySql successfully");
            _isReady = true;
        }
        catch (Exception ex) {
            throw new Exception("Error while connecting to databse: " + ex.getMessage());
        }
    }
    
    public void close()
    {
        _isReady = false;
        try
        {
            _connection.close();
        }
        catch (Exception ex) { }
    }
    
    public ResultSet select(String query) throws Exception
    {
        if (!_isReady)
        {
            throw new Exception("DbConnection isn't ready for executing queries");
        }
        try
        {
            return _connection.createStatement().executeQuery(query);
        }
        catch (Exception ex) {
            return null;
        }
    }
    
    public int update(String query) throws Exception
    {
        if (!_isReady)
        {
            throw new Exception("DbConnection isn't ready for executing queries");
        }
        try
        {
            return _connection.createStatement().executeUpdate(query);
        }
        catch (Exception ex) {
            return 0;
        }
    }
    
    public int insert(String query, Object[] cols) throws Exception
    {
        if (!_isReady)
        {
            throw new Exception("DbConnection isn't ready for executing queries");
        }
        PreparedStatement statement = _connection.prepareStatement(query, Statement.RETURN_GENERATED_KEYS);
        for (int i = 0; i < cols.length; i++)
        {
            statement.setString(i + 1, cols[i].toString());
        }
        int affectedRows = statement.executeUpdate();
        if (affectedRows == 0)
        {
            throw new Exception("0 affected rows");
        }

        try (ResultSet generatedKeys = statement.getGeneratedKeys())
        {
            if (generatedKeys.next())
            {
                return (int)generatedKeys.getLong(1);
            }
            else
            {
                throw new Exception("No id obtained");
            }
        }
    }
}
