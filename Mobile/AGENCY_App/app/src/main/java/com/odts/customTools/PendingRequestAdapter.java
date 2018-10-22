package com.odts.customTools;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.support.annotation.NonNull;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.odts.activities.R;
import com.odts.activities.RequestActivity;
import com.odts.activities.RequestDetailActivity;
import com.odts.models.ListRequest;
import com.odts.models.Request;
import com.odts.services.RequestService;
import com.odts.utils.CallBackData;

import java.util.List;

public class PendingRequestAdapter extends RecyclerView.Adapter<PendingRequestAdapter.MyViewHolder> {
    private Context context;
    private List<ListRequest> listRequest;
    RequestService requestService;

    public class MyViewHolder extends RecyclerView.ViewHolder {
        public TextView rqName, crDate, rqNameDT;
        public MyViewHolder(View view) {
            super(view);
            rqName = (TextView) view.findViewById(R.id.txtRequestNamee);
            crDate = (TextView) view.findViewById(R.id.txtCreateDatee);
            rqNameDT = (TextView) view.findViewById(R.id.txtRequestNameee);
            view.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    int position = getAdapterPosition();
                    if(position != RecyclerView.NO_POSITION) {
                        Toast.makeText(context,String.valueOf(listRequest.get(position).getRequestId()),Toast.LENGTH_SHORT).show();

//                        intent.putExtra("requestID", listRequest.get(position).getRequestId());
                        final RequestService requestService = new RequestService();
                        requestService.requestDetail(context, listRequest.get(position).getRequestId(), new CallBackData<ListRequest>() {
                            @Override
                            public void onSuccess(ListRequest listRequestt) {

//                                SharedPreferences share = context.getSharedPreferences("ODTS", 0);
//                                SharedPreferences.Editor edit = share.edit();
//                                String agencyId = share.getString("requestName", "");
//                                rqNameDT.setText("3");
                                Intent intent = new Intent(context, RequestDetailActivity.class);
                                context.startActivity(intent);
                            }

                            @Override
                            public void onFail(String message) {

                            }
                        });



                    }
                }
            });
        }
    }
    public PendingRequestAdapter(Context context, List<ListRequest> listRequest) {
        this.context = context;
        this.listRequest = listRequest;
    }
    @Override
    public MyViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View itemView = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.activity_list_item, parent, false);

        return new MyViewHolder(itemView);
    }
    @Override
    public void onBindViewHolder(final MyViewHolder holder, int position) {
        ListRequest album = listRequest.get(position);
        holder.rqName.setText(album.getRequestName());
        holder.crDate.setText(album.getCreateDate());

    }

    @Override
    public int getItemCount() {
        return listRequest.size();
    }

//    Activity context;
//    int resource;
//    List<ListRequest> objects;
//
//    public PendingRequestAdapter(@NonNull Activity context, int resource, @NonNull List<ListRequest> objects) {
//        super(context, resource, objects);
//        this.context= context;
//        this.resource=resource;
//        this.objects=objects;
//    }
//    @Override
//    public View getView(int position, View convertView, ViewGroup parent) {
//        LayoutInflater inflater= this.context.getLayoutInflater();
//        View row = inflater.inflate(this.resource,null);
//
//        TextView txtRequestName = (TextView) row.findViewById(R.id.txtRequestName);
//        TextView txtCreateDate = (TextView) row.findViewById(R.id.txtCreateDate);
//        /** Set data to row*/
//        final ListRequest serviceItem = this.objects.get(position);
//        txtRequestName.setText(serviceItem.getRequestName());
//        txtCreateDate.setText(serviceItem.getCreateDate());
//        /**Set Event Onclick*/
//        return row;
//    }
}
