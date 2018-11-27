package com.odts.it_supporter_app.apiCaller;

import android.app.Activity;
import android.support.annotation.NonNull;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageButton;
import android.widget.TextView;

import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.models.Device;
import com.odts.it_supporter_app.models.RequestTask;
import com.odts.it_supporter_app.services.TaskService;
import com.odts.it_supporter_app.utils.CallBackData;

import java.util.List;

import cn.refactor.library.SmoothCheckBox;

public class DeviceAdapter extends ArrayAdapter<Device> {
    Activity context;
    int resource;
    List<Device> objects;

    public DeviceAdapter(@NonNull Activity context, int resource, @NonNull List<Device> objects) {
        super(context, resource, objects);
        this.context = context;
        this.resource = resource;
        this.objects = objects;
    }

    @Override
    public View getView(final int position, View convertView, ViewGroup parent) {
        LayoutInflater inflater = this.context.getLayoutInflater();
        View row = inflater.inflate(this.resource, null);
        final Device device = this.objects.get(position);
        TextView deviceName = (TextView) row.findViewById(R.id.txtDeviceName);
        deviceName.setText(device.getDeviceName());
        return row;
    }
}
