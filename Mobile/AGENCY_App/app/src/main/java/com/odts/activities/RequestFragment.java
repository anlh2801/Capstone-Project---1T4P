package com.odts.activities;

import android.os.Bundle;
import android.support.design.widget.TabLayout;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentStatePagerAdapter;
import android.support.v4.view.ViewPager;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.Toolbar;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.ToxicBakery.viewpager.transforms.FlipHorizontalTransformer;
import com.ToxicBakery.viewpager.transforms.FlipVerticalTransformer;
import com.ToxicBakery.viewpager.transforms.RotateDownTransformer;
import com.ToxicBakery.viewpager.transforms.RotateUpTransformer;
import com.ToxicBakery.viewpager.transforms.TabletTransformer;
import com.ToxicBakery.viewpager.transforms.ZoomOutSlideTransformer;
import com.odts.customTools.PendingRequestAdapter;


public class RequestFragment extends Fragment {

    private Toolbar toolbar;
    private TabLayout tabLayout;
    private ViewPager viewPager;
    private RecyclerView recyclerView;
    private PendingRequestAdapter pendingRequestAdapter;
    private com.melnykov.fab.FloatingActionButton btnCreate;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        ;
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View v = inflater.inflate(R.layout.fragment_request, container, false);
        toolbar = (Toolbar) v.findViewById(R.id.toolbar);
        ((AppCompatActivity) getActivity()).setSupportActionBar(toolbar);
        viewPager = (ViewPager) v.findViewById(R.id.viewpagerrr);
        setupViewPager(viewPager);
//        viewPager.setOffscreenPageLimit(1);
        tabLayout = (TabLayout) v.findViewById(R.id.tabs);
        tabLayout.setupWithViewPager(viewPager);
        return v;
    }


    private void setupViewPager(ViewPager viewPager) {
        PagerAdapter adapter = new PagerAdapter(getActivity().getSupportFragmentManager());
        viewPager.setAdapter(adapter);
        viewPager.setPageTransformer(true, new RotateDownTransformer());
    }

    public class PagerAdapter extends FragmentStatePagerAdapter {

        PagerAdapter(FragmentManager fragmentManager) {
            super(fragmentManager);
        }

        @Override
        public Fragment getItem(int position) {
            Fragment frag = null;
            switch (position) {
                case 0:
                    frag = new PendingFragment();
                    break;
                case 1:
                    frag = new ProcessingFragment();
                    break;
                case 2:
                    frag = new DoneFragment();
                    break;
                case 3:
                    frag = new CancleFragment();
                    break;
            }
            return frag;
        }

        @Override
        public int getCount() {
            return 4;
        }

        @Override
        public CharSequence getPageTitle(int position) {
            String title = "";
            switch (position) {
                case 0:
                    title = "Chờ xử lý";
                    break;
                case 1:
                    title = "Đang xử lý";
                    break;
                case 2:
                    title = "Hoàn thành";
                    break;
                case 3:
                    title = "Hủy bỏ";
                    break;

            }
            return title;
        }
    }
}
