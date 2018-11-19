package com.odts.it_supporter_app.customTools;

import android.app.Activity;
import android.support.annotation.NonNull;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;

import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.models.Request;
import com.odts.it_supporter_app.models.RequestGroupMonth;

import java.util.List;

public class RequestGroupAdapter extends ArrayAdapter<Request> {
    Activity context;
    int resource;
    List<Request> objects;

    public RequestGroupAdapter(@NonNull Activity context, int resource, @NonNull List<Request> objects) {
        super(context, resource, objects);
        this.context = context;
        this.resource = resource;
        this.objects = objects;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        LayoutInflater inflater = this.context.getLayoutInflater();
        View row = inflater.inflate(this.resource, null);

        TextView txtRequestName = (TextView) row.findViewById(R.id.txtRequestName);
        TextView txtAgencyName = (TextView) row.findViewById(R.id.txtAgencyName);
        TextView txtEndDate = (TextView) row.findViewById(R.id.txtEndDate);
        TextView txtCreateDate = (TextView) row.findViewById(R.id.txtCreateDate);

        /** Set data to row*/
        final Request request = this.objects.get(position);
        txtRequestName.setText(request.getRequestName());
        txtAgencyName.setText(request.getAgencyName());
        txtEndDate.setText(request.getEndTime());
        txtCreateDate.setText(request.getCreateDate());

        return row;
    }
}
