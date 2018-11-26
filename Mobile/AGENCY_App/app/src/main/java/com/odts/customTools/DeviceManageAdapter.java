package com.odts.customTools;

import android.app.Activity;
import android.app.Dialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.support.annotation.NonNull;
import android.support.v7.app.AlertDialog;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.TextView;

import com.odts.activities.EditDeviceActivity;
import com.odts.activities.R;
import com.odts.models.Device;

import java.util.List;

public class DeviceManageAdapter extends ArrayAdapter<Device> {
    Activity context;
    int resource;
    List<Device> objects;

    public DeviceManageAdapter(@NonNull Activity context, int resource, @NonNull List<Device> objects) {
        super(context, resource, objects);
        this.context = context;
        this.resource = resource;
        this.objects = objects;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        LayoutInflater inflater = this.context.getLayoutInflater();
        View row = inflater.inflate(this.resource, null);

        ImageView imgManageDevice = (ImageView) row.findViewById(R.id.imgManageDevice);
        TextView txtDeviceCodeManage = (TextView) row.findViewById(R.id.txtDeviceCodeManage);
        TextView txtDeviceNameManage = (TextView) row.findViewById(R.id.txtDeviceNameManage);

        ImageButton btnDetailsDevice = (ImageButton) row.findViewById(R.id.btnDetailsDevice);
        ImageButton btnEdit = (ImageButton) row.findViewById(R.id.btnEditDevice);

        /** Set data to row*/
        final Device device = this.objects.get(position);
        txtDeviceCodeManage.setText("Mã: " + device.getDeviceCode());
        txtDeviceNameManage.setText(device.getDeviceName());

        if (device.getDeviceTypeId() == 1) {
            imgManageDevice.setImageResource(R.drawable.ic_wifi_white_64dp);
        } else if (device.getDeviceTypeId() == 2) {
            imgManageDevice.setImageResource(R.drawable.ic_videocam_whilte_64dp);
        } else if (device.getDeviceTypeId() == 4) {
            imgManageDevice.setImageResource(R.drawable.ic_computer_whilte_64dp);
        } else {
            imgManageDevice.setImageResource(R.drawable.ic_widgets_white_24dp);
        }
        btnEdit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(getContext(), EditDeviceActivity.class);
                intent.putExtra("deviceId", device.getDeviceId());
                intent.putExtra("deviceName", device.getDeviceName());
                intent.putExtra("deviceCode", device.getDeviceCode());
                intent.putExtra("ip", device.getIp());
                intent.putExtra("port", device.getPort());
                getContext().startActivity(intent);
            }
        });
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
