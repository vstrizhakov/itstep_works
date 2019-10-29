/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dz_java_5_1;

/**
 *
 * @author 09220
 */
public class ThrowMoney extends Exception
{

    static void BankrotExeption() throws Exception
    {
        throw new Exception("Ошибка! Не возможно отнять");
    }
    static void NegativeMoneyExeption() throws Exception
    {
        throw new Exception("Ошибка! попытка инициализации Money отрицательной суммой");
    }
}
