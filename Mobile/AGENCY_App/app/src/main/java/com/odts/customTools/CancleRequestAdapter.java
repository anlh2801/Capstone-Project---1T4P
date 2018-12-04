package com.odts.customTools;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.support.annotation.NonNull;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.odts.activities.DoneDetailActivity;
import com.odts.activities.R;
import com.odts.activities.RequestDetailActivity;
import com.odts.models.Device;
import com.odts.models.Request;
import com.odts.models.RequestGroupMonth;
import com.odts.services.RequestService;

import java.util.ArrayList;
import java.util.List;

public class CancleRequestAdapter extends ArrayAdapter<RequestGroupMonth> {
    Activity context;
    int resource;
    List<RequestGroupMonth> objects;

    public CancleRequestAdapter(@NonNull Activity context, int resource, @NonNull List<RequestGroupMonth> objects) {
        super(context, resource, objects);
        this.context = context;
        this.resource = resource;
        this.objects = objects;
    }
    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        LayoutInflater inflater = this.context.getLayoutInflater();
        View row = inflater.inflate(this.resource, null);
        TextView txtThangNam = (TextView) row.findViewById(R.id.txtThangNam);
        LinearLayout lvDetailsThangNam = (LinearLayout) row.findViewById(R.id.detailsRequestGroup);
        final RequestGroupMonth requestGroupMonth = this.objects.get(position);
        txtThangNam.setText(requestGroupMonth.getMonthYearGroup());

        for (final Request item : requestGroupMonth.getRequestOfITSupporter()) {
            View view = inflater.inflate(R.layout.cancel_item, null);
            TextView txtRequestName = (TextView) view.findViewById(R.id.txtRequestNameCan);
            TextView txtEndDate = (TextView) view.findViewById(R.id.udDateCan);
            txtRequestName.setText(item.getAgencyName() + " - " + item.getRequestName());
            txtEndDate.setText("Hủy vào lúc: " + item.getUpdateDate());
            lvDetailsThangNam.addView(view);
        }
        return row;
    }
}
