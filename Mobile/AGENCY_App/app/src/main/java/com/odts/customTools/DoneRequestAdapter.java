package com.odts.customTools;

import android.content.Context;
import android.content.Intent;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.odts.activities.DoneDetailActivity;
import com.odts.activities.R;
import com.odts.models.Device;
import com.odts.models.Request;

import java.util.ArrayList;
import java.util.List;

public class DoneRequestAdapter extends RecyclerView.Adapter<DoneRequestAdapter.MyViewHolder> {
    private Context context;
    private List<Request> listRequest;
    Integer requestID;

    public DoneRequestAdapter(Context context, List<Request> listRequest) {
        this.context = context;
        this.listRequest = listRequest;
    }

    public class MyViewHolder extends RecyclerView.ViewHolder {
        public TextView rqName, endDate, createDate;

        public MyViewHolder(View view) {
            super(view);
            rqName = (TextView) view.findViewById(R.id.txtRequestNameDone);
            endDate = (TextView) view.findViewById(R.id.udDateDone);
            createDate = (TextView) view.findViewById(R.id.txtEndDateDone);
            view.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    int position = getAdapterPosition();
                    if (position != RecyclerView.NO_POSITION) {
                        Intent intent = new Intent(context, DoneDetailActivity.class);
                        intent.putExtra("requestID", listRequest.get(position).getRequestId());
                        intent.putExtra("requestName", listRequest.get(position).getRequestName());
                        intent.putExtra("itName", listRequest.get(position).getiTSupporterName());
                        intent.putExtra("createDate", listRequest.get(position).getCreateDate());
                        ArrayList<String> listDeviceName = new ArrayList<>();
                        Device device = new Device();
                        for (int i = 0; i < listRequest.get(position).getTicket().size(); i++) {
                            listDeviceName.add(listRequest.get(position).getTicket().get(i).getDeviceName());
                        }
                        intent.putStringArrayListExtra("listDevice", listDeviceName);
                        context.startActivity(intent);
                    }
                }
            });
        }

    }


    @Override
    public DoneRequestAdapter.MyViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View itemView = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.done_item, parent, false);
        return new DoneRequestAdapter.MyViewHolder(itemView);
    }

    @Override
    public void onBindViewHolder(final DoneRequestAdapter.MyViewHolder holder, int position) {
        Request album = listRequest.get(position);
        holder.rqName.setText(album.getRequestName());
        holder.endDate.setText("Xác nhận hoàn thành: " + album.getUpdateDate());
        holder.createDate.setText("Tạo vào: " + album.getCreateDate());
        requestID = album.getRequestId();
    }

    @Override
    public int getItemCount() {
        return listRequest.size();
    }
}
