/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package threads;

/**
 *
 * @author PC
 */
public class PauseableThread extends Thread {
    private boolean isPause = false;
    private boolean _isInterrupted = false;
    
    public void pauseOn()
    {
        isPause = true;
    }
    
    public void pauseOff()
    {
        isPause = false;
    }
    
    private void checkPause() throws InterruptedException
    {
        while (isPause)
        {
            Thread.sleep(100);
        }
    }
    
    @Override
    public void run()
    {
        try
        {
            while (true)
            {
                System.out.println("1. Открывается духовой шкаф");
                try
                {
                    Thread.sleep(500);
                }
                catch (InterruptedException ex) {
                    _isInterrupted = true;
                }
                
                checkPause();
                
                System.out.println("2. Включается газ");
                try
                {
                    Thread.sleep(500);
                }
                catch (InterruptedException ex) {
                    _isInterrupted = true;
                }
                
                System.out.println("3. Зажигается газ");
                try
                {
                    Thread.sleep(500);
                }
                catch (InterruptedException ex) {
                    _isInterrupted = true;
                }
                
                checkPause();
                
                System.out.println("4. Загружается тесто");
                try
                {
                    Thread.sleep(500);
                }
                catch (InterruptedException ex) {
                    _isInterrupted = true;
                }
                
                System.out.println("5. Закрывается духовой шкаф");
                try
                {
                    Thread.sleep(500);
                }
                catch (InterruptedException ex) {
                    _isInterrupted = true;
                }
                
                checkPause();
                if (_isInterrupted)
                {
                    System.out.println("Работа потока была прервана");
                    break;
                }
            }
        }
        catch (InterruptedException ex) {
            
        }
    }   
}
