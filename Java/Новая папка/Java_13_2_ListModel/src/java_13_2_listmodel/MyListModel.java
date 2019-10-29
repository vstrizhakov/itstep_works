/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package java_13_2_listmodel;

import java.util.ArrayList;
import java.util.Collection;
import javafx.print.Collation;
import javax.swing.ListModel;
import javax.swing.event.ListDataEvent;
import javax.swing.event.ListDataListener;

/**
 *
 * @author 09220
 */
public class MyListModel implements ListModel<MyPoint>
{
    private ArrayList<MyPoint> data = new ArrayList<>();
    private ArrayList<ListDataListener> listeners = new ArrayList<>(); //cлушатели
    
    public MyListModel(MyPoint[] points)
    {
       for(MyPoint p:points)
           this.data.add(p);
    }
    public MyListModel(Collection points)
    {
        this.data.addAll(points);
    }
    public void add(MyPoint p)
    {
        this.data.add(p);
        ListDataEvent LDE = new ListDataEvent(this, ListDataEvent.INTERVAL_ADDED
                ,this.data.size()-1, this.data.size());
        for(ListDataListener L :this.listeners )
            L.intervalAdded(LDE);
    }
    public void insert(MyPoint p, int index)
    {
        this.data.add(index, p);
        ListDataEvent LDE = new ListDataEvent(this, ListDataEvent.INTERVAL_ADDED, index, index);
        for(ListDataListener L :this.listeners)
            L.intervalAdded(LDE);
    }
    public void remove(MyPoint p)
    {
        int index = this.data.indexOf(p);
        if(index == -1) return;
  
        this.data.remove(p);
        
        ListDataEvent LDE = new ListDataEvent(this, ListDataEvent.INTERVAL_REMOVED, index, index);
        for(ListDataListener L :this.listeners )
            L.intervalRemoved(LDE);
    }
    public void removeAt(int index)
    {
        this.data.remove(index);
        
        ListDataEvent LDE = new ListDataEvent(this, ListDataEvent.INTERVAL_REMOVED, index, index);
        for(ListDataListener L :this.listeners )
            L.intervalRemoved(LDE);
    }
    public void set(MyPoint p, int index)
    {
        this.data.set(index, p);
        
        ListDataEvent LDE = new ListDataEvent(this, ListDataEvent.CONTENTS_CHANGED, index, index);
        for(ListDataListener L :this.listeners )
            L.contentsChanged(LDE);
    }
    @Override
    public int getSize()
    {
        return this.data.size();
    }

    @Override
    public MyPoint getElementAt(int index)
    {
        return this.data.get(index);
    }

    @Override
    public void addListDataListener(ListDataListener l)
    {
        this.listeners.add(l);
        System.out.println("Добавлен слушшатель : "+l.getClass().getName());
    }

    @Override
    public void removeListDataListener(ListDataListener l)
    {
        this.listeners.remove(l);
    }
    
}
