package com.odts.customTools;

import android.app.Activity;
import android.content.Intent;
import android.support.annotation.NonNull;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.TextView;
import android.widget.Toast;

import com.odts.activities.MainActivity;
import com.odts.activities.R;
import com.odts.activities.RequestActivity;
import com.odts.models.Device;
import com.odts.models.Request;
import com.odts.models.ServiceItem;

import java.util.List;

public class DeviceRemoveAdapter extends ArrayAdapter<Device> {
    Activity context;
    int resource;
    List<Device> objects;

    public DeviceRemoveAdapter(@NonNull Activity context, int resource, @NonNull List<Device> objects) {
        super(context, resource, objects);
        this.context = context;
        this.resource = resource;
        this.objects = objects;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        LayoutInflater inflater = this.context.getLayoutInflater();
        View row = inflater.inflate(this.resource, null);

        TextView txtDeviceCodeDelete = (TextView) row.findViewById(R.id.txtDeviceCodeDelete);
        TextView txtDeviceNameDelete = (TextView) row.findViewById(R.id.txtDeviceNameDelete);

        ImageButton btnRemoveDeviceToListRequest = (ImageButton) row.findViewById(R.id.btnRemoveDeviceToListRequest);
        /** Set data to row*/
        final Device device = this.objects.get(position);
        txtDeviceCodeDelete.setText(device.getDeviceCode());
        txtDeviceNameDelete.setText(device.getDeviceName());


        /**Set Event Onclick*/
        btnRemoveDeviceToListRequest.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                objects.remove(device);
                notifyDataSetChanged();
            }
        });

        return row;
    }
}
