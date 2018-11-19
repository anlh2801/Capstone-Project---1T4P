package com.odts.it_supporter_app.customTools;

import android.app.Activity;
import android.content.DialogInterface;
import android.support.annotation.NonNull;
import android.support.v7.app.AlertDialog;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.TextView;

import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.activities.MainActivity;
import com.odts.it_supporter_app.models.ITSupporterStatistic;
import com.odts.it_supporter_app.models.RequestGroupMonth;

import java.util.List;

public class RequestITSupporterStatisticAdapter extends ArrayAdapter<RequestGroupMonth> {
    Activity context;
    int resource;
    List<RequestGroupMonth> objects;

    public RequestITSupporterStatisticAdapter(@NonNull Activity context, int resource, @NonNull List<RequestGroupMonth> objects) {
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
        ListView lvDetailsThangNam = (ListView) row.findViewById(R.id.lvDetailsThangNam);

        /** Set data to row*/
        final RequestGroupMonth requestGroupMonth = this.objects.get(position);
        txtThangNam.setText(requestGroupMonth.getMonthYearGroup());
        RequestGroupAdapter requestGroupAdapter = new RequestGroupAdapter((MainActivity)(parent.getContext()), R.layout.done_item, requestGroupMonth.getRequestOfITSupporter());
        lvDetailsThangNam.setAdapter(requestGroupAdapter);



        return row;
    }
}
