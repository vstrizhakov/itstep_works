/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package interfaces;

import java.util.ArrayList;

/**
 *
 * @author PC
 */
public class Bank
{
    private ArrayList<Cashouter> _cashouters = new ArrayList<>();
    private ArrayList<Card> _cards = new ArrayList<>();

    private int _currentCashouter = 0; 

    public Bank()
    {
        _cashouters.add(new ATM());
        _cashouters.add(new Cashier("Мария", "Ивановна"));
        _cashouters.add(new ATM());
        _cashouters.add(new Cashier("Иван", "Бороветц"));
        _cashouters.add(new Cashier("Михаил", "Макаренко"));
    }
    
    public void addCard(Card card)
    {
        _cards.add(card);
    }

    public void CashOut(Owner owner)
    {
        Card card = null;
        for (Card c : _cards)
        {
                if (c.getOwner() == owner)
                {
                        card = c;
                        break;
                }
        }
        if (card == null)
        {
            System.out.println("Вы не являетесь клиентов банка \"Бла-Бла-Бла\"");
            return;
        }
        if (_currentCashouter < _cashouters.size())
        {
            while (true)
            {
                Cashouter cashouter = _cashouters.get(_currentCashouter++);
                System.out.println("Здравствуйте, " + owner.getFirstName() + " " + owner.getLastName());
                if (cashouter instanceof Cashier)
                {
                    Cashier cashier = (Cashier)cashouter;
                    System.out.println("Вас обслуживает кассир " + cashier.getFullName());
                }
                else
                {
                    System.out.println("Вас приветствует банкомат банка \"Бла-Бла-Бла\"");
                }
                System.out.println("Баланс Вашей карты составляет: " + Math.round(card.getBalance()) + " грн.");
                double request = 0;
                do
                {
                    System.out.println("Учтите, что Вы не можете снять большую сумму, чем у Вас имеется на карте.");
                    System.out.println("Так же, если Вы введете \"0\", операция завершится.");
                    System.out.print("Какую сумму Вы хотите снять? (> 0) : ");
                    request = ConsoleHelper.readDouble();
                } while (request < 0);
                if (request == 0) return;

                if (cashouter.cashOut(card, request))
                {
                    if (cashouter instanceof Cashier)
                    {
                        Cashier cashier = (Cashier)cashouter;
                        System.out.println("Держите Ваши " + String.valueOf(Math.round(request)) + " грн.");
                    }
                    else
                    {
                        System.out.println("Вы успешно сняли " + String.valueOf(Math.round(request)) + " грн.");
                    }
                    System.out.println("На Вашем счету осталось: " + Math.round(card.getBalance()));
                    System.out.println("Спасибо, что пользуетесь нашими услугами.");
                }
                else
                {
                    System.out.println("На Вашем счету недостаточно средств.");
                }
                _currentCashouter--;
                System.out.print("Желаете повторить операцию? (Да/Другое): ");
                String answer = ConsoleHelper.readLine();
                if (answer.contentEquals("Да"))
                {
                    continue;
                }
                break;
            }
        }
        else
        {
            System.out.println("На данный момент все пункты выдачи средств с кредитной карты заняты. Попробуйте позже.");
        }                
    }
}
