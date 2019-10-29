/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package products;

import java.awt.BorderLayout;
import java.awt.FlowLayout;
import java.awt.event.*;
import java.sql.ResultSet;
import java.util.ArrayList;
import javax.swing.*;
import javax.swing.event.TableModelEvent;
import javax.swing.event.TableModelListener;
import javax.swing.table.DefaultTableModel;

/**
 *
 * @author PC
 */
public class Form extends JFrame
{
    private DbConnection _db;
    private DefaultTableModel _products;
    private DefaultTableModel _categories;
    private boolean _wasLastProductModified = true;
    private boolean _wasLastCategoryModified = true;
    private ArrayList<Category> _categoriesList = new ArrayList<>();
    private JComboBox _categoriesComboBox;
    
    public Form(DbConnection db)
    {
        _db = db;
        
        setTitle("Products");
        setSize(1200, 600);       
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        
        String[] productsHeaders = { "Id", "Name", "Category", "Weight", "Price" };
        String[] categoriesHeaders = { "Id", "Name" };
        
        _products = new DefaultTableModel();
        _products.setColumnIdentifiers(productsHeaders);
        _categories = new DefaultTableModel();
        _categories.setColumnIdentifiers(categoriesHeaders);
        
        JTable productsTable = new JTable(_products)
        {
            @Override
            public boolean isCellEditable(int row, int col)
            {
                return !(col == 0);
            }
        };
        JTable categoriesTable = new JTable(_categories)
        {
            @Override
            public boolean isCellEditable(int row, int col)
            {
                return !(col == 0);
            }
        };
        productsTable.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
        categoriesTable.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
        
        JScrollPane productsScroll = new JScrollPane(productsTable);
        JScrollPane categoriesScroll = new JScrollPane(categoriesTable);
        
        JPanel leftPanel = new JPanel(new BorderLayout());
        JPanel rightPanel = new JPanel(new BorderLayout());
        
        JPanel categoriesPanel = new JPanel(new FlowLayout(FlowLayout.LEFT));
        JButton addCategoryButton = new JButton("Добавить");
        addCategoryButton.addActionListener(new ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent ae)
            {
                if (!_wasLastCategoryModified) return;
                _wasLastCategoryModified = false;
                
                _categories.addRow(new Object[] { });
            }
        });
        JButton removeCategoryButton = new JButton("Удалить");
        removeCategoryButton.addActionListener(new ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent ae)
            {
                int selectedIndex = categoriesTable.getSelectedRow();
                if (selectedIndex != -1)
                {
                    Category category = Category.fromTableModel(_categories, selectedIndex);
                    
                    int productsCount = _products.getRowCount();
                    boolean currentCategoryHasProducts = false;
                    for (int i = 0; i < productsCount; i++)
                    {
                        Product product = Product.fromTableModel(_products, i);
                        if (product.getCategoryId() == category.getId())
                        {
                            currentCategoryHasProducts = true;
                            break;
                        }
                    }
                    if (currentCategoryHasProducts)
                    {
                        JOptionPane.showMessageDialog(Form.this, "В категории \"" + category.getName() + "\" ещё находятся товары.\nЧтобы удалить эту категорию, сначала удалите товары, которые относятся к ней.");
                        return;
                    }
                    try
                    {
                        _db.update("DELETE FROM products WHERE id = '" + category.getId() + "';");
                    }
                    catch (Exception ex) {
                        System.out.println("Error while deleting category: " + ex.getMessage());
                    }
                    Category categoryToRemove = Form.this.findCategoryById(category.getId());
                    _categoriesList.remove(categoryToRemove);
                    _categoriesComboBox.addItem(categoryToRemove);
                    _categories.removeRow(selectedIndex);
                    if (_categories.getRowCount() == selectedIndex)
                    {
                        selectedIndex--;
                    }
                    if (selectedIndex >= 0)
                    {
                        categoriesTable.setRowSelectionInterval(selectedIndex, selectedIndex);
                    }
                }
            }
        });
        categoriesPanel.add(addCategoryButton);
        categoriesPanel.add(removeCategoryButton);
        
        JPanel productsPanel = new JPanel(new FlowLayout(FlowLayout.LEFT));
        JButton addProductButton = new JButton("Добавить");
        addProductButton.addActionListener(new ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent ae)
            {
                if (!_wasLastProductModified) return;
                _wasLastProductModified = false;
                
                _products.addRow(new Object[] { "", _categoriesList.get(0) });
            }
        });
        JButton removeProductButton = new JButton("Удалить");
        removeProductButton.addActionListener(new ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent ae)
            {
                int selectedIndex = productsTable.getSelectedRow();
                if (selectedIndex != -1)
                {
                    Product product = Product.fromTableModel(_products, selectedIndex);
                    try
                    {
                        _db.update("DELETE FROM products WHERE id = '" + product.getId() + "';");
                    }
                    catch (Exception ex) {
                        System.out.println("Error while deleting product: " + ex.getMessage());
                    }
                    _products.removeRow(selectedIndex);
                    if (_products.getRowCount() == selectedIndex)
                    {
                        selectedIndex--;
                    }
                    if (selectedIndex >= 0)
                    {
                        productsTable.setRowSelectionInterval(selectedIndex, selectedIndex);
                    }
                }
            }
        });
        productsPanel.add(addProductButton);
        productsPanel.add(removeProductButton);
        
        _products.addTableModelListener(new TableModelListener()
        {
            private boolean _isUpdating = false;
            
            @Override
            public void tableChanged(TableModelEvent tme)
            {
                if (_isUpdating) return;
                int type = tme.getType();
                int selectedRowIndex = tme.getFirstRow();
                int lastRowIndex = _products.getRowCount() - 1;
                if (type == -1) // Removed
                {
                    if (!_wasLastProductModified && selectedRowIndex > lastRowIndex)
                    {
                        _wasLastProductModified = true;
                    }
                }
                else if (type == 0) // Edited
                {
                    Product product = Product.fromTableModel(_products, selectedRowIndex);
                    try
                    {
                        ResultSet set = null;
                        if (!_wasLastProductModified && selectedRowIndex == lastRowIndex)
                        {
                            int id = _db.insert("INSERT INTO products (category_id, name, price, weight) VALUES (?, ?, ?, ?)",
                                        new Object[] { product.getCategoryId(), product.getName(), product.getPrice(), product.getWeight() });
                            set = _db.select("SELECT * FROM products WHERE id = '" + id + "'");
                            
                            _wasLastProductModified = true;
                        }
                        else
                        {
                            _db.update("UPDATE products SET category_id = '" + product.getCategoryId() + "', " +
                                                            "name = '" + product.getName() + "', " +
                                                            "price = '" + product.getPrice() + "', " +
                                                            "weight = '" + product.getWeight() + "' " +
                                                            "WHERE id = '" + product.getId() + "';");
                            set = _db.select("SELECT * FROM products WHERE id = '" + product.getId() + "'");
                        }
                        set.next();
                        Product updatedProduct = Product.fromResultSet(set);
                        Category categoryToSet = Form.this.findCategoryById((updatedProduct.getCategoryId()));
                        _isUpdating = true;
                        _products.setValueAt(updatedProduct.getId(), selectedRowIndex, 0);
                        _products.setValueAt(categoryToSet, selectedRowIndex, 1);
                        _products.setValueAt(updatedProduct.getName(), selectedRowIndex, 2);
                        _products.setValueAt(updatedProduct.getWeight(), selectedRowIndex, 3);
                        _products.setValueAt(updatedProduct.getPrice(), selectedRowIndex, 4);
                        _isUpdating = false;
                    }
                    catch (Exception ex) {
                        System.out.println(ex.getMessage());
                    }
                }
            }
        });
        
        _categories.addTableModelListener(new TableModelListener()
        {
            private boolean _isUpdating = false;
            
            @Override
            public void tableChanged(TableModelEvent tme)
            {
                if (_isUpdating) return;
                int type = tme.getType();
                int selectedRowIndex = tme.getFirstRow();
                int lastRowIndex = _categories.getRowCount() - 1;
                if (type == -1) // Removed
                {
                    if (!_wasLastCategoryModified && selectedRowIndex > lastRowIndex)
                    {
                        _wasLastCategoryModified = true;
                    }
                }
                else if (type == 0) // Edited
                {
                    Category category = Category.fromTableModel(_categories, selectedRowIndex);
                    try
                    {
                        ResultSet set = null;
                        Category updatedCategory = null;
                        if (!_wasLastCategoryModified && selectedRowIndex == lastRowIndex)
                        {
                            int id = _db.insert("INSERT INTO categories (name) VALUES (?)",
                                        new Object[] { category.getName() });
                            set = _db.select("SELECT * FROM categories WHERE id = '" + id + "'");
                            set.next();
                            updatedCategory = Category.fromResultSet(set);
                            _categoriesList.add(updatedCategory);
                            _categoriesComboBox.addItem(updatedCategory);
                            _wasLastCategoryModified = true;
                        }
                        else
                        {
                            _db.update("UPDATE categories SET name = '" + category.getName() + "' " +
                                                            "WHERE id = '" + category.getId() + "';");
                            set = _db.select("SELECT * FROM categories WHERE id = '" + category.getId() + "'");
                            set.next();
                            updatedCategory = Category.fromResultSet(set);
                        }
                        _isUpdating = true;
                        _categories.setValueAt(updatedCategory.getId(), selectedRowIndex, 0);
                        _categories.setValueAt(updatedCategory.getName(), selectedRowIndex, 1);
                        _isUpdating = false;
                    }
                    catch (Exception ex) {
                        System.out.println(ex.getMessage());
                    }
                }
            }
        });
        
        leftPanel.add(categoriesPanel, BorderLayout.NORTH);
        leftPanel.add(categoriesScroll);
        rightPanel.add(productsPanel, BorderLayout.NORTH);
        rightPanel.add(productsScroll);
        
        JSplitPane splitPane = new JSplitPane(JSplitPane.HORIZONTAL_SPLIT, leftPanel, rightPanel);
        setContentPane(splitPane);
        
        try
        {
            _categoriesComboBox = new JComboBox();
            ResultSet set = _db.select("SELECT * FROM categories");
            while (set.next())
            {
                Category category = Category.fromResultSet(set);
                _categories.addRow(category.toArray());
                _categoriesComboBox.addItem(category);
                _categoriesList.add(category);
            }
            
            productsTable.getColumnModel().getColumn(1).setCellEditor(new DefaultCellEditor(_categoriesComboBox));
            
            set = _db.select("SELECT * FROM products");
            while (set.next())
            {
                Object[] productObject = Product.fromResultSet(set).toArray();
                productObject[1] = findCategoryById((int)productObject[1]);
                _products.addRow(productObject);
            }
        }
        catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
    }
    
    public Category findCategoryById(int id)
    {
        Category result = null;
        for (int i = 0; i < _categoriesList.size(); i++)
        {
            if (_categoriesList.get(i).getId() == id)
            {
                result = _categoriesList.get(i);
                break;
            }
        }
        return result;
    }
}
