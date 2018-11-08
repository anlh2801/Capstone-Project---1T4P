package com.odts.customTools;

import android.app.Activity;
import android.graphics.Color;
import android.support.annotation.NonNull;
import android.support.v7.widget.CardView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import com.odts.activities.R;
import com.odts.models.AgencyStatistical;
import com.odts.models.ServiceItem;
import com.odts.models.Status;
import com.odts.utils.Enums;

import java.util.List;

import static com.odts.utils.Enums.*;

public class AgencyStatisticalAdapter extends ArrayAdapter<AgencyStatistical> {

    Activity context;
    int resource;
    List<AgencyStatistical> objects;

    public AgencyStatisticalAdapter(@NonNull Activity context, int resource, @NonNull List<AgencyStatistical> objects) {
        super(context, resource, objects);
        this.context= context;
        this.resource=resource;
        this.objects=objects;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        LayoutInflater inflater= this.context.getLayoutInflater();
        View row = inflater.inflate(this.resource,null);
        ImageView imgIconHome = (ImageView) row.findViewById(R.id.imgIconHome);
        TextView txtServiceItemTitle = (TextView) row.findViewById(R.id.txtServiceItemTitle);
        TextView txtAwaintingHome = (TextView) row.findViewById(R.id.txtAwaintingHome);
        TextView txtProcessingHome = (TextView) row.findViewById(R.id.txtProcessingHome);
        TextView txtDoneHome = (TextView) row.findViewById(R.id.txtDoneHome);
        TextView txtCancelHome = (TextView) row.findViewById(R.id.txtCancelHome);
        CardView cardView = (CardView) row.findViewById(R.id.cv);
        CardView cardViewFooter = (CardView) row.findViewById(R.id.cvFooter);
        if (position % 3 == 0) {
            cardView.setCardBackgroundColor(Color.parseColor("#4DB6AC"));
            cardViewFooter.setCardBackgroundColor(Color.parseColor("#26A69A"));
        } else if (position % 3 == 1) {
            cardView.setCardBackgroundColor(Color.parseColor("#26A69A"));
            cardViewFooter.setCardBackgroundColor(Color.parseColor("#009688"));
        }
        else if (position % 3 == 2){
            cardView.setCardBackgroundColor(Color.parseColor("#00695C"));
            cardViewFooter.setCardBackgroundColor(Color.parseColor("#004D40"));
        }



        /** Set data to row*/
        final AgencyStatistical agencyStatistical = this.objects.get(position);
        if (agencyStatistical.getServiceId() == 1) {
            imgIconHome.setBackgroundResource(R.drawable.ic_wifi_white_64dp);
        } else if (agencyStatistical.getServiceId() == 2) {
            imgIconHome.setBackgroundResource(R.drawable.ic_videocam_whilte_64dp);
        } else if (agencyStatistical.getServiceId() == 3) {
            imgIconHome.setBackgroundResource(R.drawable.ic_computer_whilte_64dp);
        } else {
            imgIconHome.setBackgroundResource(R.drawable.ic_widgets_white_24dp);
        }
        txtServiceItemTitle.setText(agencyStatistical.getServiceName());
        List<Status> statusList = agencyStatistical.getStatuses();
        if (statusList.size() > 0) {
            String awaintingHome = "0";
            String processingHome = "0";
            String doneHome = "0";
            String cancelHome = "0";
            for (Status stt: statusList ) {
                if (stt.getStatusId() ==  RequestStatusEnum.Pending.getIntValue()) {
                    awaintingHome = stt.getNumberOfStatus();
                } else if (stt.getStatusId() ==  RequestStatusEnum.Processing.getIntValue()) {
                    processingHome = stt.getNumberOfStatus();
                } else if (stt.getStatusId() ==  RequestStatusEnum.Done.getIntValue()) {
                    doneHome = stt.getNumberOfStatus();
                } else if (stt.getStatusId() ==  RequestStatusEnum.Cancel.getIntValue()) {
                    cancelHome = stt.getNumberOfStatus();
                }
            }
            txtAwaintingHome.setText(awaintingHome);
            txtProcessingHome.setText(processingHome);
            txtDoneHome.setText(doneHome);
            txtCancelHome.setText(cancelHome);
        } else {
            txtAwaintingHome.setText("0");
            txtProcessingHome.setText("0");
            txtDoneHome.setText("0");
            txtCancelHome.setText("0");
        }



        return row;
    }
}
