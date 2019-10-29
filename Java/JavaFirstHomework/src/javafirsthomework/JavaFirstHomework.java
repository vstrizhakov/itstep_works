/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javafirsthomework;

import java.io.InputStreamReader;
import java.io.LineNumberReader;

/**
 *
 * @author PC
 */
public class JavaFirstHomework {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        writeLine("Подсчитать, сколько раз встречается слово в предложении. Пользователь водит предложение и слово.");
        writeLine("================================================================================================");
        searchWordInTheSentence();
        writeLine("Пользователь вводит строку. Необходимо выполнить замену указанного слова на другое.");
        writeLine("================================================================================================");
        replaceWordInTheSentence();
        writeLine("Пользователь вводит строку. Необходимо подсчитать кол-во слов в предложении.");
        writeLine("================================================================================================");
        countWordsInTheSentence();
        writeLine("Пользователь вводит строку. Необходимо подсчитать, сколько в строке цифр, букв и других символов.");
        writeLine("================================================================================================");
        countNumbersLettersAndOtherSymbolsInTheSentence();
        


//        try
//        {
//            Fraction f = new Fraction(20, 21);
//            Fraction f2 = f.Clone();
//            f.Reduce();
//            System.out.println(f.getNumerator() + "/" + f.getDenominator());
//        }
//        catch (Exception ex) {
//            System.out.println(ex.getMessage() + "1");
//        }
    }
    
    public static void searchWordInTheSentence()
    {
        write("Введите предложение: ");
        String sentence = readLine();
        write("Введите слово для поиска: ");
        String word = readLine();
        int count = 0;
        int a = sentence.indexOf(word);
        while (a != -1)
        {
            count++;
            a = sentence.indexOf(word, a + word.length() + 1);
        }
        writeLine("Слово \"" + word + "\" встречалось " + count + " раз");
    }
    
    public static void replaceWordInTheSentence()
    {
         write("Введите предложение: ");
        String sentence = readLine();
        write("Введите старое слово: ");
        String oldWord = readLine();
        write("Введите новое слово: ");
        String newWord  = readLine();
        sentence = sentence.replace(oldWord, newWord);
        writeLine(sentence);
    }
    
    public static void countWordsInTheSentence()
    {
        write("Введите предложение: ");
        String sentence = readLine();
        int count = (sentence.contentEquals("")) ? 0 : 1;
        int a = sentence.indexOf(" ");
        while (a != -1)
        {
            count++;
            a = sentence.indexOf(" ", a + 2);
        }
        writeLine("В предложении " + count + " слов");
    }
    
    public static void countNumbersLettersAndOtherSymbolsInTheSentence()
    {
        write("Введите предложение: ");
        String sentence = readLine();
        int digits = 0, letters = 0, symbols = 0;
        for (int i = 0; i < sentence.length(); i++)
        {
            String ch = String.valueOf(sentence.charAt(i));
            if (ch.matches("\\d"))
            {
                digits++;
            }
            else if (ch.matches("[a-zA-Zа-яА-Я]"))
            {
                letters++;
            }
            else
            {
                symbols++;
            }
        }
        writeLine("Цифр - " + digits);
        writeLine("Букв - " + letters);
        writeLine("Других символов - " + symbols);
    }
    
    public static void writeLine(String str)
    {
        System.out.println(str);
    }
    
    public static void write(String str)
    {
        System.out.print(str);
    }
    
    public static String readLine() {
        String S = "";
        try {
            LineNumberReader LNR = new LineNumberReader(new InputStreamReader(System.in, "CP1251"));
            S = LNR.readLine();
        } catch (Exception ioe) {
            S = "";
        }
        return S;
    }
    
    public static int readInt()
    {
        String input = readLine();
        try
        {
            return Integer.parseInt(input);
        }
        catch (Exception ex) {
            return 0;
        }
    }
    
    public static void fractions()
    {
        DynamicArray array = new DynamicArray();
        do
        {
            write("\nМассив: ");
            array.print();
            writeLine("1. Добавить число");
            writeLine("2. Вставить число");
            writeLine("3. Найти число");
            writeLine("4. Размер массива");
            writeLine("5. Получить число по индексу");
            writeLine("Любой другой символ - выход из меню.");
            String input = readLine();
            
            switch (input)
            {
                case "1":
                {
                    write("Введите целое число: ");
                    int tmp = readInt();
                    array.add(tmp);
                    break;
                }
                case "2":
                {
                    while (true)
                    {
                        write("Введите целое число: ");
                        int tmp = readInt();
                        write("Введите индекс, куда нужно вставить число: ");
                        int index = readInt();
                        boolean wasInserted = array.insert(tmp, index);
                        if (!wasInserted)
                        {
                            writeLine("Похоже, вы ввели неверный индекс, число не было вставлено.");
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
                }
                case "3":
                {
                    write("Введите индекс, из которого нужно удалить число: ");
                    int index = readInt();
                    array.remove(index);
                    break;
                }
                case "4":
                {
                    break;
                }
                case "5":
                {
                    break;
                }
                default:
                    break;
            }
        } while(true);
    }
}
