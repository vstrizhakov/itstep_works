/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package threadsarraysynchronization;

/**
 *
 * @author PC
 */
public class ThreadsArraySynchronization {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        MyArray array = new MyArray();
        Event event = new Event(2, 0);
        
        ArrayFiller filler = new ArrayFiller(array, event);
        ArrayCounter counter = new ArrayCounter(array, event);
        ArrayAverager averager = new ArrayAverager(array, event);
        
        filler.start();
        counter.start();
        averager.start();
    }
    
}
