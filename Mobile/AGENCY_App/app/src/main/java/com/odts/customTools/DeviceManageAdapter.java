package com.odts.customTools;

import android.app.Activity;
import android.app.Dialog;
import android.content.DialogInterface;
import android.support.annotation.NonNull;
import android.support.v7.app.AlertDialog;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageButton;
import android.widget.TextView;

import com.odts.activities.R;
import com.odts.models.Device;

import java.util.List;

public class DeviceManageAdapter extends ArrayAdapter<Device> {
    Activity context;
    int resource;
    List<Device> objects;

    public DeviceManageAdapter(@NonNull Activity context, int resource, @NonNull List<Device> objects) {
        super(context, resource, objects);
        this.context= context;
        this.resource=resource;
        this.objects=objects;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        LayoutInflater inflater= this.context.getLayoutInflater();
        View row = inflater.inflate(this.resource,null);

        TextView txtDeviceCodeManage = (TextView) row.findViewById(R.id.txtDeviceCodeManage);
        TextView txtDeviceNameManage = (TextView) row.findViewById(R.id.txtDeviceNameManage);

        ImageButton btnDetailsDevice = (ImageButton) row.findViewById(R.id.btnDetailsDevice);
        /** Set data to row*/
        final Device device = this.objects.get(position);
        txtDeviceCodeManage.setText(device.getDeviceCode());
        txtDeviceNameManage.setText(device.getDeviceName());


        /**Set Event Onclick*/
        btnDetailsDevice.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                AlertDialog alertDialog = new AlertDialog.Builder(getContext()).create();
                alertDialog.setTitle(device.getDeviceName());
                alertDialog.setMessage("IP:\n" + device.getIp());
                alertDialog.setButton(AlertDialog.BUTTON_NEUTRAL, "OK",
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int which) {
                                dialog.dismiss();
                            }
                        });
                alertDialog.show();
            }
        });

        return row;
    }
}