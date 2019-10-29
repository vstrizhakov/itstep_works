package com.vstrizhakov.recyclerview_;

import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

public class PersonViewHolder extends RecyclerView.ViewHolder
{
	public TextView TvName;
	public TextView TvSpeciality;
	public TextView TvAge;
	public ImageView IvAvatar;
	
	public PersonViewHolder(View v)
	{
		super(v);
		TvName = v.findViewById(R.id.tvName);
		TvSpeciality = v.findViewById(R.id.tvSpeciality);
		TvAge = v.findViewById(R.id.tvAge);
		IvAvatar = v.findViewById(R.id.ivAvatar);
	}
}
