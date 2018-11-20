package com.odts.customTools;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.support.annotation.NonNull;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TextView;

import com.odts.activities.R;
import com.odts.activities.StatusTimelineActivity;
import com.odts.models.Device;
import com.odts.models.Request;
import com.odts.models.RequestGroupMonth;
import com.odts.services.RequestService;
import com.odts.utils.Enums;

import java.util.ArrayList;
import java.util.List;

public class ProcessRequestAdapter extends ArrayAdapter<RequestGroupMonth> {
    Activity context;
    int resource;
    List<RequestGroupMonth> objects;
    RequestService requestService;
    int requestID = 0;

    public ProcessRequestAdapter(@NonNull Activity context, int resource, @NonNull List<RequestGroupMonth> objects) {
        super(context, resource, objects);
        this.context = context;
        this.resource = resource;
        this.objects = objects;
    }

    @Override
    public View getView(final int position, View convertView, ViewGroup parent) {
        LayoutInflater inflater = this.context.getLayoutInflater();
        View row = inflater.inflate(this.resource, null);
        TextView txtThangNam = (TextView) row.findViewById(R.id.txtThangNam);
        LinearLayout lvDetailsThangNam = (LinearLayout) row.findViewById(R.id.detailsRequestGroup);
        final RequestGroupMonth requestGroupMonth = this.objects.get(position);
        txtThangNam.setText(requestGroupMonth.getMonthYearGroup());
        for (final Request item : requestGroupMonth.getRequestOfITSupporter()) {
            View view = inflater.inflate(R.layout.process_item, null);
            TextView txtRequestName = (TextView) view.findViewById(R.id.txtRequestNamePro);
            TextView txtNoD = (TextView) view.findViewById(R.id.txtNoDPro);
            TextView txtCreateDate = (TextView) view.findViewById(R.id.txtDate);
            TextView txtHero = (TextView) view.findViewById(R.id.txtHero);
            txtRequestName.setText(item.getAgencyName() + " - " + item.getRequestName());
            txtCreateDate.setText("Tạo vào: " + item.getCreateDate());
            txtNoD.setText("Thiết bị cần xử lý: " + item.getNod());
            txtHero.setText("Xử lý bởi: " + item.getiTSupporterName());
            requestID = item.getRequestId();
            requestService = new RequestService();
            lvDetailsThangNam.addView(view);
            view.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    Intent intent = new Intent(context, StatusTimelineActivity.class);
                    intent.putExtra("requestName", item.getRequestName());
                    intent.putExtra("requestID", item.getRequestId());
                    intent.putExtra("itName", item.getiTSupporterName());
                    intent.putExtra("createDate", item.getCreateDate());
                    intent.putExtra("phoneNumber", item.getiTSupporterPhone());
                    ArrayList<String> listDeviceName = new ArrayList<>();
                    Device device = new Device();
                    for (int i = 0; i < item.getTicket().size(); i++) {
                        listDeviceName.add(item.getTicket().get(i).getDeviceName());
                    }
                    intent.putStringArrayListExtra("listDevice", listDeviceName);
                    context.startActivity(intent);
                }
            });
        }


        return row;
    }
}
