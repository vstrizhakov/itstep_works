package com.vstrizhakov.calculator;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity
{
	private TextView result;
	
	private String first = "";
	private String second = "";
	private String operator = "";
	private boolean isAfterEvaluation = false;
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		result = findViewById(R.id.result);
	}
	
	public void BtnClicked(View view)
	{
		String operation = ((Button)view).getText().toString();
		String result = "";
		switch (operation)
		{
			case "0":
			case "1":
			case "2":
			case "3":
			case "4":
			case "5":
			case "6":
			case "7":
			case "8":
			case "9":
			case ".":
			{
				if (isAfterEvaluation)
				{
					first = "";
					isAfterEvaluation = false;
				}
				if (operator.contentEquals(""))
				{
					if (operation.contentEquals(".") && !first.contains(operation))
					{
						if (first.isEmpty())
						{
							first = "0.";
						}
						else
						{
							first += operation;
						}
					}
					else
					{
						String tmp = first + operation;
						if (operation.contentEquals("0"))
						{
							first = tmp;
						}
						else
						{
							try
							{
								Double num = Double.valueOf(tmp);
								if (num * 10 % 10 == 0)
								{
									first = Integer.valueOf(tmp).toString();
								}
								else
								{
									first = num.toString();
								}
							}
							catch (Exception ex)
							{
							}
						}
					}
				}
				else
				{
					if (operation.contentEquals(".") && !second.contains(operation))
					{
						if (second.isEmpty())
						{
							second = "0.";
						}
						else
						{
							second += operation;
						}
					}
					else
					{
						String tmp = second + operation;
						if (operation.contentEquals("0"))
						{
							second = tmp;
						}
						else
						{
							try
							{
								Double num = Double.valueOf(tmp);
								if (num * 10 % 10 == 0)
								{
									second = Integer.valueOf(tmp).toString();
								}
								else
								{
									second = num.toString();
								}
							}
							catch (Exception ex)
							{
							}
						}
					}
				}
				result = first + " " + operator + " " + second;
				break;
			}
			case "-":
			case "+":
			case "*":
			case "/":
			{
				if (!first.contentEquals(""))
				{
					operator = operation;
					isAfterEvaluation = false;
				}
				result = first + " " + operator + " " + second;
				break;
			}
			case "=":
			{
				if (!first.contentEquals("") && !second.contentEquals("") && !operator.contentEquals(""))
				{
					if (first.charAt(first.length() - 1) == '.') first += "0";
					if (second.charAt(second.length() - 1) == '.') second += "0";
					Double firstNum = Double.valueOf(first);
					Double secondNum = Double.valueOf(second);
					switch (operator)
					{
						
						case "-":
						{
							result = String.valueOf(firstNum - secondNum);
							break;
						}
						case "+":
						{
							result = String.valueOf(firstNum + secondNum);
							break;
						}
						case "*":
						{
							result = String.valueOf(firstNum * secondNum);
							break;
						}
						case "/":
						{
							if (secondNum != 0)
							{
								result = String.valueOf(firstNum / secondNum);
							}
							else
							{
								result = "На ноль делить нельзя";
							}
							break;
						}
					}
					try
					{
						Double resultNum = Double.valueOf(result);
						if (resultNum * 10 % 10 == 0)
						{
							result = String.valueOf((int)(double)resultNum);
						}
						first = result;
						isAfterEvaluation = true;
					}
					catch (Exception ex)
					{
						first = "";
					}
					second = "";
					operator = "";
				}
				else
				{
					result = first + " " + second;
				}
				break;
			}
		}
		this.result.setText(result);
	}
}
