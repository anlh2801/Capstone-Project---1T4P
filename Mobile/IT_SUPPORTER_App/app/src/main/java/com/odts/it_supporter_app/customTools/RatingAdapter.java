package com.odts.it_supporter_app.customTools;

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
import android.widget.RatingBar;
import android.widget.TextView;

import com.odts.it_supporter_app.R;

import com.odts.it_supporter_app.models.Request;
import com.odts.it_supporter_app.models.RequestGroupMonth;
import com.willy.ratingbar.ScaleRatingBar;

import java.util.List;

public class RatingAdapter extends ArrayAdapter<RequestGroupMonth> {


    Activity context;
    int resource;
    List<RequestGroupMonth> objects;

    public RatingAdapter(@NonNull Activity context, int resource, @NonNull List<RequestGroupMonth> objects) {
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
            View view = inflater.inflate(R.layout.rating_item, null);
            TextView requestName = (TextView) view.findViewById(R.id.txtRequestNameRate);
            TextView agencyName = (TextView) view.findViewById(R.id.txtAgencyNameRate);
            TextView feedback = (TextView) view.findViewById(R.id.txtFeedbackRate);
            ScaleRatingBar ratingBar = (ScaleRatingBar) view.findViewById(R.id.simpleRatingBarRate);
            requestName.setText(item.getRequestName());
            agencyName.setText("bởi      " + item.getAgencyName() + "-     lúc    " +item.getCreateDate());
            ratingBar.setRating(item.getRating());
            feedback.setText(item.getFeedBack());
            lvDetailsThangNam.addView(view);
        }
        return row;
    }

//    public class MyViewHolder extends RecyclerView.ViewHolder {
//        public TextView requestName, agencyName, feedback;
//        public ScaleRatingBar ratingBar;
//        public MyViewHolder(View view) {
//            super(view);
//            requestName = (TextView) view.findViewById(R.id.txtRequestNameRate);
//            agencyName = (TextView) view.findViewById(R.id.txtAgencyNameRate);
//            feedback = (TextView) view.findViewById(R.id.txtFeedbackRate);
//            ratingBar = (ScaleRatingBar) view.findViewById(R.id.simpleRatingBarRate);
//            ratingBar.setClickable(false);
//        }
//    }
//
//    public RatingAdapter(Context context, List<Request> listRating) {
//        this.context = context;
//        this.listRating = listRating;
//    }
//
//    @Override
//    public RatingAdapter.MyViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
//        View itemView = LayoutInflater.from(parent.getContext())
//                .inflate(R.layout.rating_item, parent, false);
//        return new RatingAdapter.MyViewHolder(itemView);
//    }
//
//    @Override
//    public void onBindViewHolder(final RatingAdapter.MyViewHolder holder, int position) {
//        Request request = listRating.get(position);
//        holder.requestName.setText(listRating.get(position).getRequestName());
//        holder.agencyName.setText(listRating.get(position).getAgencyName());
//        holder.feedback.setText(listRating.get(position).getFeedBack());
//        holder.ratingBar.setRating(listRating.get(position).getRating());
//    }
//
//    @Override
//    public int getItemCount() {
//        return listRating.size();
//    }
}
