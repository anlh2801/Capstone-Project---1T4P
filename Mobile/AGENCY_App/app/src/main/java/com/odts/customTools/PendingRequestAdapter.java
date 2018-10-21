package com.odts.customTools;

import android.app.Activity;
import android.content.Intent;
import android.support.annotation.NonNull;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.TextView;

import com.odts.activities.R;
import com.odts.activities.RequestActivity;
import com.odts.models.ListRequest;

import java.util.List;

public class PendingRequestAdapter extends ArrayAdapter<ListRequest> {
    Activity context;
    int resource;
    List<ListRequest> objects;

    public PendingRequestAdapter(@NonNull Activity context, int resource, @NonNull List<ListRequest> objects) {
        super(context, resource, objects);
        this.context= context;
        this.resource=resource;
        this.objects=objects;
    }
    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        LayoutInflater inflater= this.context.getLayoutInflater();
        View row = inflater.inflate(this.resource,null);

        TextView txtRequestName = (TextView) row.findViewById(R.id.txtRequestName);
        TextView txtCreateDate = (TextView) row.findViewById(R.id.txtCreateDate);
        /** Set data to row*/
        final ListRequest serviceItem = this.objects.get(position);
        txtRequestName.setText(serviceItem.getRequestName());
        txtCreateDate.setText(serviceItem.getCreateDate());
        /**Set Event Onclick*/
        return row;
    }
}
