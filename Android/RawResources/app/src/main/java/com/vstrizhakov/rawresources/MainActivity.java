package com.vstrizhakov.rawresources;

import android.animation.Animator;
import android.animation.AnimatorInflater;
import android.animation.AnimatorSet;
import android.animation.ObjectAnimator;
import android.animation.ValueAnimator;
import android.graphics.Path;
import android.graphics.drawable.AnimationDrawable;
import android.renderscript.Sampler;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.util.TypedValue;
import android.view.Gravity;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.view.animation.AccelerateDecelerateInterpolator;
import android.view.animation.BounceInterpolator;
import android.view.animation.PathInterpolator;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.FrameLayout;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.zip.Inflater;

public class MainActivity extends AppCompatActivity
{
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		Toolbar toolbar = findViewById(R.id.toolbar);
		setSupportActionBar(toolbar);
		toolbar.setTitle("Title");
		toolbar.setSubtitle("Subtitle");
		toolbar.setLogo(R.drawable.android);
		toolbar.setNavigationIcon(R.drawable.android);
		toolbar.setNavigationOnClickListener(new View.OnClickListener()
		{
			@Override
			public void onClick(View v)
			{
				Toast.makeText(MainActivity.this, "Navigation Icon CLicked", Toast.LENGTH_LONG).show();
			}
		});
		
		ImageView ivOne = findViewById(R.id.ivOne);
		ivOne.setBackgroundResource(R.drawable.frame_animation_smile);
		
		ListView lvMovies = findViewById(R.id.lvMovies);
		String[] genres = { "Action", "Fantastic", "Drama", "Melodrama", "Comedy", "Adventure", "Cartoon", "Thriller", "LoveStory" };
		ArrayList<MyMovie> movies = new ArrayList<>();
		for (int i = 0; i < 50; i++)
		{
			movies.add(new MyMovie(makeMovieTitle(),
					genres[(int) Math.random() * genres.length],
					2000 + (int) (Math.random() * 20)));
		}
		ArrayAdapter<MyMovie> adapter =
				new ArrayAdapter<MyMovie>(this, R.layout.list_item_value_animation, R.id.tvTitle, movies)
				{
					@Override
					public View getView(int position, View convertView, ViewGroup parent)
					{
						View view = super.getView(position, convertView, parent);
						MyMovie movie = getItem(position);
						
						TextView title = view.findViewById(R.id.tvTitle);
						TextView genre = view.findViewById(R.id.tvGenre);
						TextView year = view.findViewById(R.id.tvYear);
						
						title.setText(movie.title);
						genre.setText(movie.genre);
						year.setText(movie.year + "");
						
						
						
						return view;
					}
				};
		lvMovies.setAdapter(adapter);
		
		lvMovies.setOnItemClickListener(
				new AdapterView.OnItemClickListener()
				{
					@Override
					public void onItemClick(AdapterView<?> parent, View view, int position, long id)
					{
						MainActivity.this.toggleValueAnimation(view);
					}
				}
		);
	}
	
	public void toggleValueAnimation(View view)
	{
		final LinearLayout llButtonHolder = view.findViewById(R.id.llButtonHolder);
		final LinearLayout llItemHolder = view.findViewById(R.id.llItemHolder);
		final TextView tvDelete = view.findViewById(R.id.tvDelete);
		final TextView tvEdit = view.findViewById(R.id.tvEdit);
		
		AnimatorSet set;
		if (llButtonHolder.getWidth() == 0)
		{
			set = (AnimatorSet)AnimatorInflater.loadAnimator(this, R.animator.item_rise_value_animator);
		}
		else
		{
			set = (AnimatorSet)AnimatorInflater.loadAnimator(this, R.animator.item_drop_value_animator);
		}
		ArrayList<Animator> animators = set.getChildAnimations();
		
		ValueAnimator vaRise = (ValueAnimator)animators.get(0);
		vaRise.addUpdateListener(new ValueAnimator.AnimatorUpdateListener()
		{
			@Override
			public void onAnimationUpdate(ValueAnimator animation)
			{
				int curWidth = (int)animation.getAnimatedValue();
				FrameLayout.LayoutParams layoutParams = new FrameLayout.LayoutParams(curWidth, FrameLayout.LayoutParams.MATCH_PARENT);
				layoutParams.gravity = Gravity.RIGHT;
				llButtonHolder.setLayoutParams(layoutParams);
			}
		});
		
		ValueAnimator vaRiseTextSize = (ValueAnimator)animators.get(1);
		vaRiseTextSize.addUpdateListener(new ValueAnimator.AnimatorUpdateListener()
		{
			@Override
			public void onAnimationUpdate(ValueAnimator animation)
			{
				float curTextSize = (float)animation.getAnimatedValue();
				tvDelete.setTextSize(TypedValue.COMPLEX_UNIT_SP, curTextSize);
				tvEdit.setTextSize(TypedValue.COMPLEX_UNIT_SP, curTextSize);
			}
		});
		
		ValueAnimator vaRiseShift = (ValueAnimator)animators.get(2);
		vaRiseShift.addUpdateListener(new ValueAnimator.AnimatorUpdateListener()
		{
			@Override
			public void onAnimationUpdate(ValueAnimator animation)
			{
				int curX = (int)animation.getAnimatedValue();
				llItemHolder.setX(curX);
			}
		});
		set.start();
	}
	
	public void textClick(View view)
	{
		toggleValueAnimation((View)view.getParent().getParent());
	}
	
	private String makeMovieTitle()
	{
		String[] first = { "Winter", "House", "Summer", "Road", "Human", "Wind", "Solider" };
		String[] second = { "Blues", "Alarm", "Song", "Sea", "River", "Boat", "Desert" };
		String[] third = { "Three", "Cloud", "Sun", "Day", "Year", "Story", "Love" };
		String[] z = { " and ", " or ", " at ", " under ", " before ", " after " };
		
		String str = first[(int) Math.random() * first.length] + " " + second[(int) Math.random() * second.length] + z[(int) Math.random() * z.length] +
				third[(int) Math.random() * third.length];
		return str;
	}
	
	@Override
	public boolean onCreateOptionsMenu(Menu menu)
	{
		MenuInflater inflater = getMenuInflater();
		inflater.inflate(R.menu.main_menu, menu);
		return true;
	}
	
	@Override
	public boolean onOptionsItemSelected(MenuItem item)
	{
		int id = item.getItemId();
		switch (id)
		{
			case R.id.action_settings:
				Toast.makeText(this, "Item 'Settings' selected", Toast.LENGTH_LONG).show();
				break;
			case R.id.action_options:
				Toast.makeText(this, "Item 'Options' selected", Toast.LENGTH_LONG).show();
				break;
			case R.id.action_alpha:
			{
				ObjectAnimator objectAnimator = (ObjectAnimator) AnimatorInflater.loadAnimator(this, R.animator.alpha_property_animator);
				objectAnimator.setTarget(findViewById(R.id.flOne));
				objectAnimator.start();
			}
			return true;
			case R.id.action_background:
			{
				ObjectAnimator objectAnimator = (ObjectAnimator) AnimatorInflater.loadAnimator(this, R.animator.background_property_animator);
				objectAnimator.setTarget(findViewById(R.id.flTwo));
				objectAnimator.start();
			}
			return true;
			case R.id.action_position:
			{
				ObjectAnimator objectAnimator = (ObjectAnimator) AnimatorInflater.loadAnimator(this, R.animator.position_property_animator);
				objectAnimator.setTarget(findViewById(R.id.flThree));
				objectAnimator.start();
			}
			return true;
			case R.id.action_rotation:
			{
				ValueAnimator valueAnimator = (ValueAnimator) AnimatorInflater.loadAnimator(this, R.animator.rotation_value_animator);
				valueAnimator.addUpdateListener(new ValueAnimator.AnimatorUpdateListener()
				{
					@Override
					public void onAnimationUpdate(ValueAnimator animation)
					{
						float value = (float) animation.getAnimatedValue();
						findViewById(R.id.flFour).setRotation(value);
					}
				});
				valueAnimator.start();
			}
			return true;
			case R.id.action_frame:
			{
				ImageView ivOnew = findViewById(R.id.ivOne);
				AnimationDrawable animationDrawable = (AnimationDrawable) ivOnew.getBackground();
				if (animationDrawable.isRunning())
				{
					animationDrawable.stop();
				}
				else
				{
					animationDrawable.start();
				}
			}
			return true;
			case R.id.action_complex:
			{
				AnimatorSet set = (AnimatorSet) AnimatorInflater.loadAnimator(this, R.animator.complex_value_animator);
				ArrayList<Animator> animators = set.getChildAnimations();
				
				final ValueAnimator rotationAnimator = (ValueAnimator) animators.get(0);
				rotationAnimator.addUpdateListener(new ValueAnimator.AnimatorUpdateListener()
				{
					@Override
					public void onAnimationUpdate(ValueAnimator animation)
					{
						float value = (float) rotationAnimator.getAnimatedValue();
						findViewById(R.id.flFive).setRotation(value);
					}
				});
				
				final ValueAnimator positionAnimator = (ValueAnimator) animators.get(1);
				positionAnimator.addUpdateListener(new ValueAnimator.AnimatorUpdateListener()
				{
					@Override
					public void onAnimationUpdate(ValueAnimator animation)
					{
						float value = (float) positionAnimator.getAnimatedValue();
						findViewById(R.id.flFive).setX(value);
					}
				});
				rotationAnimator.setInterpolator(new BounceInterpolator());
				Path path = new Path();
				path.lineTo(0.25f, 0.25f);
				path.moveTo(0.25f, 0.5f);
				path.lineTo(1f, 1f);
				positionAnimator.setInterpolator(new PathInterpolator(path));
				set.start();
			}
			return true;
		}
		return super.onOptionsItemSelected(item);
	}
}
