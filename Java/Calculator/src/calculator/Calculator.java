/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package calculator;

import java.io.InputStreamReader;
import java.io.LineNumberReader;

/**
 *
 * @author PC
 */
public class Calculator {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        double a, b, result;
        char operator;

        System.out.print("Введите первое число: ");
        a = getDouble();
        System.out.print("Введите второе число: ");
        b = getDouble();
        do
        {
        System.out.print("Введите операцию, которую нужно выполнить (+-*/): ");
        operator = getString().charAt(0);
        } while (operator != '+' && operator != '-' && operator != '*' && operator != '/');
        
        switch (operator)
        {
            case '+':
                result = a + b;
                break;
            case '-':
                result = a - b;
                break;
            case '/':
                if (b == 0)
                {
                    System.out.println("Делить на ноль нельзя!");
                    return;
                }
                result = a / b;
                break;
            case '*':
                result = a * b;
                break;
            default:
                result = 0;
                break;
        }
        System.out.println("Результат: " + a + " + " + b + " = " + result);
    }

    public static String getString() {
        String S = "";
        try {
            LineNumberReader LNR = new LineNumberReader(new InputStreamReader(System.in, "CP1251"));
            S = LNR.readLine();
        } catch (Exception ioe) {
            S = "";
        }
        return S;
    }

    public static int getInt() {
        try {
            return Integer.parseInt(getString());
        } catch (Exception ie) {
            return 0;
        }
    }

    public static double getDouble() {
        try {
            return Double.parseDouble(getString());
        } catch (Exception ex) {
            return 0;
        }
    }
}

