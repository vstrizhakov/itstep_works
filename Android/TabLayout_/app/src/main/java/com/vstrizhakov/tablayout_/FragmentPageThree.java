package com.vstrizhakov.tablayout_;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import java.util.ArrayList;


public class FragmentPageThree extends Fragment
{


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        ViewGroup rootView = (ViewGroup) inflater.inflate(R.layout.fragment_page_three, container, false);

        ListView listView = rootView.findViewById(R.id.listView);

        ArrayList<String> arrayList = new ArrayList<>();
        for(int i=0; i<50; i++)
            arrayList.add("Hello "+(i+1));

        ArrayAdapter<String> adapter = new ArrayAdapter<>(this.getActivity(), android.R.layout.simple_list_item_1, arrayList);
        listView.setAdapter(adapter);

        return rootView;
    }
}
