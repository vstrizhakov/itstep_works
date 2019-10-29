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
public class FirstThread extends Thread
{
    @Override
    public void run()
    {
        int cnt = 0;
        for (int i = 0; i < 400000; i++)
        {
            System.out.println("Работает первый поток: " + (i + 1));
            if (Thread.interrupted())
            {
                cnt++;
                System.out.println("###############:" + cnt);
                System.out.flush();
                if (cnt == 2) break;
            }
        }
    }
}
