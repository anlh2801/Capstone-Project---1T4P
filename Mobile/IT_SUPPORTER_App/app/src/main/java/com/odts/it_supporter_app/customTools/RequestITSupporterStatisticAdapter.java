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
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TextView;

import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.activities.MainActivity;
import com.odts.it_supporter_app.models.ITSupporterStatistic;
import com.odts.it_supporter_app.models.Request;
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
        LinearLayout lvDetailsThangNam = (LinearLayout) row.findViewById(R.id.detailsRequestGroup);

        /** Set data to row*/
        final RequestGroupMonth requestGroupMonth = this.objects.get(position);
        txtThangNam.setText(requestGroupMonth.getMonthYearGroup());
        for (Request item: requestGroupMonth.getRequestOfITSupporter()) {
            View view = inflater.inflate(R.layout.done_item, null);
            TextView txtRequestName = (TextView) view.findViewById(R.id.txtRequestInfo);
            TextView txtEndDate = (TextView) view.findViewById(R.id.txtEndDate);
            TextView txtCreateDate = (TextView) view.findViewById(R.id.txtCreateDate);

            txtRequestName.setText(item.getAgencyName() + " - " + item.getRequestName());
            txtCreateDate.setText("Tạo vào: " + item.getCreateDate());
            txtEndDate.setText("Xác nhận hoàn thành vào: " + item.getEndTime());

            lvDetailsThangNam.addView(view);
        }

        return row;
    }
}
