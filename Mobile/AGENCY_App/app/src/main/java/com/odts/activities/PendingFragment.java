package com.odts.activities;

import android.content.Context;
import android.net.Uri;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.odts.customTools.PendingRequestAdapter;
import com.odts.models.ListRequest;
import com.odts.services.RequestService;
import com.odts.utils.CallBackData;

import java.util.ArrayList;

//import com.example.chiennt.odts_agency_mobile.R;

/**
 * A simple {@link Fragment} subclass.
 * Activities that contain this fragment must implement the
* {@link PendingFragment.OnFragmentInteractionListener} interface
 * to handle interaction events.
 * Use the {@link PendingFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class PendingFragment extends Fragment {
    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";

    // TODO: Rename and change types of parameters
    private String mParam1;
    private String mParam2;
    private RequestService requestService;
    private RecyclerView recyclerView;
    private PendingRequestAdapter pendingRequestAdapter;

//    private OnFragmentInteractionListener mListener;

    public PendingFragment() {
        // Required empty public constructor
    }

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @param param1 Parameter 1.
     * @param param2 Parameter 2.
     * @return A new instance of fragment PendingFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static PendingFragment newInstance(String param1, String param2) {
        PendingFragment fragment = new PendingFragment();
        Bundle args = new Bundle();
        args.putString(ARG_PARAM1, param1);
        args.putString(ARG_PARAM2, param2);
        fragment.setArguments(args);
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {
            mParam1 = getArguments().getString(ARG_PARAM1);
            mParam2 = getArguments().getString(ARG_PARAM2);
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
//        requestService = new RequestService();
//        requestService.getRequestByStatus(ListRequestActivity.class, 3, 1, new CallBackData<ArrayList<ListRequest>>() {
//            @Override
//            public void onSuccess(ArrayList<ListRequest> listRequests) {
//                recyclerView = (RecyclerView) inflaterfindViewById(R.id.listPending);
//                recyclerView.setLayoutManager(new LinearLayoutManager(ListRequestActivity.class));
//                pendingRequestAdapter = new PendingRequestAdapter(ListRequestActivity.class, listRequests);
//                recyclerView.setAdapter(pendingRequestAdapter);
//            }
//
//            @Override
//            public void onFail(String message) {
//
//            }
//        });
        return inflater.inflate(R.layout.fragment_pending, container, false);
    }
    @Override
    public void onActivityCreated(Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);
                requestService = new RequestService();
        requestService.getRequestByStatus(getActivity(), 3, 1, new CallBackData<ArrayList<ListRequest>>() {
            @Override
            public void onSuccess(ArrayList<ListRequest> listRequests) {
                recyclerView = (RecyclerView) getActivity().findViewById(R.id.listPending);
                recyclerView.setLayoutManager(new LinearLayoutManager(getActivity()));
                pendingRequestAdapter = new PendingRequestAdapter(getActivity(), listRequests);
                recyclerView.setAdapter(pendingRequestAdapter);
            }

            @Override
            public void onFail(String message) {

            }
        });

    }

    // TODO: Rename method, update argument and hook method into UI event
//    public void onButtonPressed(Uri uri) {
//        if (mListener != null) {
//            mListener.onFragmentInteraction(uri);
//        }
//    }

//    @Override
//    public void onAttach(Context context) {
//        super.onAttach(context);
//        if (context instanceof OnFragmentInteractionListener) {
//            mListener = (OnFragmentInteractionListener) context;
//        } else {
//            throw new RuntimeException(context.toString()
//                    + " must implement OnFragmentInteractionListener");
//        }
//    }

//    @Override
//    public void onDetach() {
//        super.onDetach();
//        mListener = null;
//    }

    /**
     * This interface must be implemented by activities that contain this
     * fragment to allow an interaction in this fragment to be communicated
     * to the activity and potentially other fragments contained in that
     * activity.
     * <p>
     * See the Android Training lesson <a href=
     * "http://developer.android.com/training/basics/fragments/communicating.html"
     * >Communicating with Other Fragments</a> for more information.
     */
//    public interface OnFragmentInteractionListener {
//        // TODO: Update argument type and name
//        void onFragmentInteraction(Uri uri);
//    }
}
