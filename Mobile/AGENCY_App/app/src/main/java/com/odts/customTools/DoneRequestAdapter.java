package com.odts.customTools;

import android.content.Context;
import android.content.Intent;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.odts.activities.R;
import com.odts.activities.RequestDetailActivity;
import com.odts.models.Request;
import com.odts.services.RequestService;

import java.util.List;

public class DoneRequestAdapter extends RecyclerView.Adapter<DoneRequestAdapter.MyViewHolder>{
    private Context context;
    private List<Request> listRequest;
    RequestService requestService;

    public class MyViewHolder extends RecyclerView.ViewHolder {
        public TextView rqName, estimes;
        public MyViewHolder(View view) {
            super(view);
            rqName = (TextView) view.findViewById(R.id.txtRequestNameDone);
            estimes = (TextView) view.findViewById(R.id.udDateDone);


            view.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    int position = getAdapterPosition();
                    if(position != RecyclerView.NO_POSITION) {
                        Intent intent = new Intent(context, RequestDetailActivity.class);
                        intent.putExtra("requestID", listRequest.get(position).getRequestId());
                        context.startActivity(intent);
                    }
                }
            });
        }
    }
    public DoneRequestAdapter(Context context, List<Request> listRequest) {
        this.context = context;
        this.listRequest = listRequest;
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
        holder.estimes.setText("Hoàn thành lúc: "+album.getUpdateDate());
    }

    @Override
    public int getItemCount() {
        return listRequest.size();
    }
}
