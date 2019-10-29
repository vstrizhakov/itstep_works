package com.vstrizhakov.recyclerview_;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import java.util.ArrayList;

public class MyRecycleAdapter extends android.support.v7.widget.RecyclerView.Adapter<PersonViewHolder>
{
	private ArrayList<Person> _dataSet;
	private Context _context;
	
	public MyRecycleAdapter(Context context, ArrayList<Person> dataSet)
	{
		_context = context;
		_dataSet = dataSet;
	}
	
	@Override
	public PersonViewHolder onCreateViewHolder(ViewGroup parent, int viewType)
	{
		View view = LayoutInflater.from(parent.getContext())
				.inflate(R.layout.my_recycler_item, parent, false);
		PersonViewHolder viewHolder = new PersonViewHolder((view));
		return viewHolder;
	}
	
	@Override
	public int getItemCount()
	{
		return _dataSet.size();
	}
	
	@Override
	public void onBindViewHolder(PersonViewHolder viewHolder, int position)
	{
		Person person = _dataSet.get(position);
		viewHolder.TvName.setText(person.Name);
		viewHolder.TvSpeciality.setText(person.Speciality);
		viewHolder.TvAge.setText(person.Age + " years old");
		viewHolder.IvAvatar.setImageDrawable(
				_context.getResources().getDrawable(
						((person.Gender)
						? R.drawable.abc
						: R.drawable.cba)
				)
		);
	}
	
}
