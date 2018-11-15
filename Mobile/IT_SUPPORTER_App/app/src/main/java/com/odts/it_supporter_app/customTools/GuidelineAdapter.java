package com.odts.it_supporter_app.customTools;

import android.app.Activity;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.support.annotation.NonNull;
import android.support.v4.content.LocalBroadcastManager;
import android.support.v7.app.AlertDialog;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.TextView;

import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.models.Guideline;

import java.util.List;

public class GuidelineAdapter extends ArrayAdapter<Guideline> {

    Activity context;
    int resource;
    List<Guideline> objects;

    public GuidelineAdapter(@NonNull Activity context, int resource, @NonNull List<Guideline> objects) {
        super(context, resource, objects);
        this.context= context;
        this.resource=resource;
        this.objects=objects;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        LayoutInflater inflater= this.context.getLayoutInflater();
        View row = inflater.inflate(this.resource,null);

        TextView txtGuideDetail = (TextView) row.findViewById(R.id.txtGuideDetail);

        Guideline guideline = this.objects.get(position);
        txtGuideDetail.setText(guideline.getGuidelineName());

        return row;
    }
}
