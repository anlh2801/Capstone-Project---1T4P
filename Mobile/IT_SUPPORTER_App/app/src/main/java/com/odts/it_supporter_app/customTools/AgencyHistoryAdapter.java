package com.odts.it_supporter_app.customTools;

import android.app.Activity;
import android.content.Intent;
import android.support.annotation.NonNull;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageButton;
import android.widget.TextView;

import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.activities.DeviceInfoActivity;
import com.odts.it_supporter_app.models.Device;
import com.odts.it_supporter_app.models.Request;

import java.util.List;

public class AgencyHistoryAdapter extends ArrayAdapter<Request> {
    Activity context;
    int resource;
    List<Request> objects;

    public AgencyHistoryAdapter(@NonNull Activity context, int resource, @NonNull List<Request> objects) {
        super(context, resource, objects);
        this.context = context;
        this.resource = resource;
        this.objects = objects;
    }

    @Override
    public View getView(final int position, View convertView, ViewGroup parent) {
        final LayoutInflater inflater = this.context.getLayoutInflater();
        View row = inflater.inflate(this.resource, null);
        final Request device = this.objects.get(position);
        TextView requestName = (TextView) row.findViewById(R.id.txtHienTuong);
        TextView createDate = (TextView) row.findViewById(R.id.txtNgayTao);
        requestName.setText(device.getRequestName());
        createDate.setText(device.getCreateDate());
        return row;
    }
}
