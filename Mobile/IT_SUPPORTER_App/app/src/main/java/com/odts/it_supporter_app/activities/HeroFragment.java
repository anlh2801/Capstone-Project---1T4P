package com.odts.it_supporter_app.activities;

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
import com.odts.it_supporter_app.R;


public class HeroFragment extends Fragment {

    private Toolbar toolbar;
    private TabLayout tabLayout;
    private ViewPager viewPager;
    private RecyclerView recyclerView;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        ;
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View v = inflater.inflate(R.layout.hero_fragment, container, false);
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
//        viewPager.setPageTransformer(true, new RotateDownTransformer());
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
                    frag = new AgencyFragment();
                    break;
                case 1:
                    frag = new DoRequestFragment();
                    break;
                case 2:
                    frag = new ToolFragment();
                    break;
            }
            return frag;
        }

        @Override
        public int getCount() {
            return 3;
        }

        @Override
        public CharSequence getPageTitle(int position) {
            String title = "";
            switch (position) {
                case 0:
                    title = "Thông tin chung";
                    break;
                case 1:
                    title = "Xử lý";
                    break;
                case 2:
                    title = "Bộ hỗ trợ";
                    break;

            }
            return title;
        }
    }
}
