/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package threadpool;

/**
 *
 * @author PC
 */
public class Pool {
    private PoolItemThread[] _threads = new PoolItemThread[10];
    private final static Pool pool = new Pool();
    
    public static Pool getThreadPool()
    {
        return pool;
    }
    
    private Pool()
    {
        for (int i = 0; i < _threads.length; i++)
        {
            _threads[i] = new PoolItemThread();
            _threads[i].setDaemon(true);
            _threads[i].start();
        }
    }
    
    public boolean execTask(Runnable r)
    {
        for (int i = 0; i < _threads.length; i++)
        {
            if (!_threads[i].isHandleTask())
            {
                _threads[i].startTask(r);
                return true;
            }
        }
        return false;
    }
}
