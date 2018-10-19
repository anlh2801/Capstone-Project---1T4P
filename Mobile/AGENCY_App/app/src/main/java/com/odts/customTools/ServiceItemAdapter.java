package com.odts.customTools;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.support.annotation.NonNull;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.odts.activities.MainActivity;
import com.odts.activities.R;
import com.odts.activities.RequestActivity;
import com.odts.models.ServiceItem;

import java.util.List;

public class ServiceItemAdapter extends ArrayAdapter<ServiceItem> {

    Activity context;
    int resource;
    List<ServiceItem> objects;

    public ServiceItemAdapter(@NonNull Activity context, int resource, @NonNull List<ServiceItem> objects) {
        super(context, resource, objects);
        this.context= context;
        this.resource=resource;
        this.objects=objects;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        LayoutInflater inflater= this.context.getLayoutInflater();
        View row = inflater.inflate(this.resource,null);

        TextView txtServiceItemTitle = (TextView) row.findViewById(R.id.txtServiceItemTitle);
        TextView txtDescription = (TextView) row.findViewById(R.id.txtDescription);
        TextView txtPrice = (TextView) row.findViewById(R.id.txtPrice);
        Button btnCreateRequest = (Button) row.findViewById(R.id.btnCreateRequest);
        /** Set data to row*/
        final ServiceItem serviceItem = this.objects.get(position);
        txtServiceItemTitle.setText(serviceItem.getServiceItemName());
        txtDescription.setText(serviceItem.getDescription());
        txtPrice.setText(serviceItem.getServiceItemPrice().toString());

        /**Set Event Onclick*/
        btnCreateRequest.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(context, RequestActivity.class);
                intent.putExtra("serviceItemId",serviceItem.getServiceItemId());
                context.startActivity(intent);
                //Toast.makeText(context, serviceItem.getServiceItemId().toString(), Toast.LENGTH_SHORT).show();
            }
        });

        return row;
    }
}
