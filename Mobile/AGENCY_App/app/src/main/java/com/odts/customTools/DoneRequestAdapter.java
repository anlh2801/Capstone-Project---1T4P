package com.odts.customTools;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.support.annotation.NonNull;
import com.odts.activities.R;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.LinearLayout;
import android.widget.TextView;
import com.odts.activities.DoneDetailActivity;
import com.odts.models.Device;
import com.odts.models.Request;
import com.odts.models.RequestGroupMonth;
import java.util.ArrayList;
import java.util.List;

public class DoneRequestAdapter extends ArrayAdapter<RequestGroupMonth> {
    Activity context;
    int resource;
    List<RequestGroupMonth> objects;

    public DoneRequestAdapter(@NonNull Activity context, int resource, @NonNull List<RequestGroupMonth> objects) {
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
            View view = inflater.inflate(R.layout.done_item, null);
            TextView txtRequestName = (TextView) view.findViewById(R.id.txtRequestNameDone);
            TextView txtEndDate = (TextView) view.findViewById(R.id.txtEndDateDone);
            TextView txtCreateDate = (TextView) view.findViewById(R.id.createDateDone);
            TextView txtHero = (TextView) view.findViewById(R.id.txtHeroName);
            txtRequestName.setText(item.getAgencyName() + " - " + item.getRequestName());
            txtCreateDate.setText("Tạo vào: " + item.getCreateDate());
            txtEndDate.setText("Xác nhận hoàn thành: " + item.getNod());
            txtHero.setText("Xử lý bởi: " + item.getiTSupporterName());
            lvDetailsThangNam.addView(view);
            view.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    Intent intent = new Intent(context, DoneDetailActivity.class);
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
