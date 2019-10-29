/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package profileform;

import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.*;
import java.util.*;
import javax.swing.*;

/**
 *
 * @author PC
 */
public class Form extends JFrame
{
	private JTextField _firstNameField;
	private JTextField _lastNameField;
	private JRadioButton _maleRadioButton;
	private JRadioButton _femaleRadioButton;
	private JComboBox _yearComboBox;
	private JComboBox _monthComboBox;
	private JComboBox _dayComboBox;
	private ArrayList<JCheckBox> _interestCheckBoxes;
	private JButton _saveButton;

	public Form()
	{
		_firstNameField = new JTextField();
		_lastNameField = new JTextField();
		_maleRadioButton = new JRadioButton("Male");
		_femaleRadioButton = new JRadioButton("Female");
		_dayComboBox = new JComboBox();
		_monthComboBox = new JComboBox();
		_yearComboBox = new JComboBox();
                _saveButton = new JButton("Save profile");
                _interestCheckBoxes = new ArrayList<>();
                _interestCheckBoxes.add(new JCheckBox("Java"));
                _interestCheckBoxes.add(new JCheckBox("PHP"));
                _interestCheckBoxes.add(new JCheckBox("Android"));
                _interestCheckBoxes.add(new JCheckBox("HTML"));
                
                ButtonGroup group = new ButtonGroup();
                group.add(_maleRadioButton);
                group.add(_femaleRadioButton);
                _maleRadioButton.setSelected(true);
                
                _dayComboBox.setPreferredSize(new Dimension(60, 30));
                _monthComboBox.setPreferredSize(new Dimension(60, 30));
                _yearComboBox.setPreferredSize(new Dimension(60, 30));

                for (int i = 1; i <= 31; i++)
                {
                    _dayComboBox.addItem(i);
                }
                for (int i = 1; i <= 12; i++)
                {
                    _monthComboBox.addItem(i);
                }
                for (int i = 1900; i < 2019; i++)
                {
                    _yearComboBox.addItem(i);
                }
		
                _saveButton.addActionListener(new ActionListener()
                {
                    @Override
                    public void actionPerformed(ActionEvent ae)
                    {
                        Profile profile = getProfileFromForm();
                        saveProfile(profile);
                    }
                });
                
		setSize(1200, 600);
		setTitle("Profile Form");
                setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
                GridBagLayout layout = new GridBagLayout();
                setLayout(layout);

                GridBagConstraints constraints = new GridBagConstraints();
                constraints.anchor = GridBagConstraints.CENTER;
                constraints.fill = GridBagConstraints.BOTH;
                constraints.gridheight = 1;
                constraints.gridwidth = 1;
                constraints.gridx = GridBagConstraints.RELATIVE;
                constraints.gridy = 0;
                constraints.insets = new Insets(3, 5, 3, 5);
                constraints.ipadx = 0;
                constraints.ipady = 0;
                constraints.weightx = 0;
                constraints.weighty = 0;
                
                constraints.gridwidth = 2;
                layout.setConstraints(_firstNameField, constraints);
                constraints.gridwidth = 1;
                layout.setConstraints(_lastNameField, constraints);
                constraints.gridy++;
                layout.setConstraints(_maleRadioButton, constraints);
                layout.setConstraints(_femaleRadioButton, constraints);
                constraints.gridy++;
                layout.setConstraints(_dayComboBox, constraints);
                layout.setConstraints(_monthComboBox, constraints);
                layout.setConstraints(_yearComboBox, constraints);
                for (JCheckBox checkBox : _interestCheckBoxes)
                {
                    constraints.gridy++;
                    constraints.gridwidth = 3;
                    layout.setConstraints(checkBox, constraints);
                }
                constraints.gridy++;
                layout.setConstraints(_saveButton, constraints);

                add(_firstNameField);
                add(_lastNameField);
                add(_maleRadioButton);
                add(_femaleRadioButton);
                add(_dayComboBox);
                add(_monthComboBox);
                add(_yearComboBox);
                for (JCheckBox checkBox : _interestCheckBoxes)
                {
                    add(checkBox);
                }
                add(_saveButton);
                
		try
		{
			FileInputStream FIS = new FileInputStream("form.dat");
			ObjectInputStream OIS = new ObjectInputStream(FIS);
			Profile profile = (Profile)OIS.readObject();
                        OIS.close();
			FillForm(profile);
		}
		catch (Exception ex) { }
	}

	private void FillForm(Profile profile)
	{
		_firstNameField.setText(profile.getFirstName());
		_lastNameField.setText(profile.getLastName());
		if (profile.getSex())
		{
			_maleRadioButton.setSelected(true);
		}
		else
		{
			_femaleRadioButton.setSelected(true);
		}
		Date birthday = profile.getBirthday();
		Calendar calendar = Calendar.getInstance();
		calendar.setTime(birthday);
		_yearComboBox.setSelectedItem(calendar.get(Calendar.YEAR));
		_monthComboBox.setSelectedItem(calendar.get(Calendar.MONTH) + 1);
		_dayComboBox.setSelectedItem(calendar.get(Calendar.DAY_OF_MONTH));
		for (JCheckBox interestCheckBox : _interestCheckBoxes)
                {
                    for (String interest : profile.getInterests())
                    {
                        if (interestCheckBox.getText().contentEquals(interest))
                        {
                            interestCheckBox.setSelected(true);
                            break;
                        }
                    }
                }
	}
        
        private Profile getProfileFromForm()
        {
            String firstName = _firstNameField.getText();
            String lastName =_lastNameField.getText();
            boolean sex = _maleRadioButton.isSelected();
            Calendar calendar = Calendar.getInstance();
            calendar.set((int)_yearComboBox.getSelectedItem(), (int)_monthComboBox.getSelectedItem() - 1, (int)_dayComboBox.getSelectedItem());
            Date birthday = calendar.getTime();
            calendar.setTime(birthday);
            
		_yearComboBox.setSelectedItem(calendar.get(Calendar.YEAR));
		_monthComboBox.setSelectedItem(calendar.get(Calendar.MONTH) + 1);
		_dayComboBox.setSelectedItem(calendar.get(Calendar.DAY_OF_MONTH));
            ArrayList<String> interests = new ArrayList<>();
            for (JCheckBox checkBox : _interestCheckBoxes)
            {
                if (checkBox.isSelected())
                {
                    interests.add(checkBox.getText());
                }
            }
            return new Profile(firstName, lastName, sex, birthday, interests);
        }
        
        private void saveProfile(Profile profile)
        {
            try
            {
                FileOutputStream FOS = new FileOutputStream("form.dat");
                ObjectOutputStream OOS = new ObjectOutputStream(FOS);
                OOS.writeObject(profile);
                OOS.close();
            }
            catch (Exception ex) { }
        }
}