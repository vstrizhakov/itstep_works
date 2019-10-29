/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package calculatorserver;

/**
 *
 * @author PC
 */
public class CalculatorServer {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        ServerThread serverThread = new ServerThread();
        serverThread.start();
    }
    
}
